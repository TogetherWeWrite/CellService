using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CellService.MessageHandlers;
using CellService.Repositories;
using CellService.Services;
using CellService.Settings;
using MessageBroker;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
            #region mq
            services.Configure<MessageQueueSettings>(Configuration.GetSection("MessageQueueSettings"));
            services.AddMessagePublisher(Configuration["MessageQueueSettings:Uri"]);
            services.AddMessageConsumer(Configuration["MessageQueueSettings:Uri"],
                "cell-service",
                builder => builder.WithHandler<WorldMessageHandler>("new-world"));
            #endregion

            #region database injection 
            services.Configure<CellServiceDatastoreSettings>(
               Configuration.GetSection("CellstoreDatabaseSettings"));

            services.AddSingleton<ICellServiceDataStoreSettings>(sp =>
                sp.GetRequiredService<IOptions<CellServiceDatastoreSettings>>().Value);
            #endregion

            #region Services injection
            services.AddTransient<IWorldEditService, WorldEditService>();
            services.AddTransient<IWorldViewService, WorldViewService>();
            #endregion

            #region Repositories Injection
            services.AddTransient<IWorldRepository, Worldrepository>();
            services.AddTransient<ICellRepository, CellRepository>();
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
