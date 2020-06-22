using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellService.Helpers;
using CellService.MessageHandlers;
using CellService.Repositories;
using CellService.Services;
using CellService.Settings;
using MessageBroker;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CellService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            #region jwt
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("JwtSettings");
            services.Configure<JwtSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                };
            });
            #endregion
            
            #region mq
            services.Configure<MessageQueueSettings>(Configuration.GetSection("MessageQueueSettings"));
            services.AddMessagePublisher(Configuration["MessageQueueSettings:Uri"]);
            services.AddMessageConsumer(Configuration["MessageQueueSettings:Uri"],
                "cell-service",
                builder => builder.WithHandler<WorldMessageHandler>("new-world").WithHandler<WorldDeleteMessageHandler>("delete-world"));
            #endregion

            #region database injection 
            services.Configure<CellServiceDatastoreSettings>(
               Configuration.GetSection("CellstoreDatabaseSettings"));

            services.AddSingleton<ICellServiceDataStoreSettings>(sp =>
                sp.GetRequiredService<IOptions<CellServiceDatastoreSettings>>().Value);
            #endregion
            
            #region Helper Injection
            services.AddTransient<IAuthenticationHelper, AuthenticationHelper>();
            services.AddTransient<IChunkHelper, ChunkHelper>();
            #endregion
            
            #region Services injection
            services.AddTransient<IWorldEditService, WorldEditService>();
            services.AddTransient<IWorldViewService, WorldViewService>();
            services.AddTransient<IChunkService, ChunkService>();
            services.AddTransient<ICellEditService, CellEditService>();
            #endregion

            #region Repositories Injection
            services.AddTransient<IWorldRepository, Worldrepository>();
            services.AddTransient<IChunkRepository, ChunkRepository>();
            #endregion
            
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors(x => x
                           .AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
