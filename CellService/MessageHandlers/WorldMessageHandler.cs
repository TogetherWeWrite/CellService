using CellService.MqMessages;
using CellService.Repositories;
using MessageBroker;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CellService.Services;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils.Messaging;

namespace CellService.MessageHandlers
{
    public class WorldMessageHandler : IMessageHandler<WorldRegisterMessage>
    {
        private IWorldEditService _worldEditService;

        public WorldMessageHandler(IWorldEditService worldEditService)
        {
            _worldEditService = worldEditService;
        }

        public Task HandleMessageAsync(string messageType, WorldRegisterMessage sendable)
        {
            _worldEditService.createWorld(sendable.Id, sendable.Title);
            return Task.CompletedTask;
        }

        public Task HandleMessageAsync(string messageType, byte[] obj)
        {
            return HandleMessageAsync(messageType, JsonSerializer.Deserialize<WorldRegisterMessage>((ReadOnlySpan<byte>)obj, (JsonSerializerOptions)null));
        }
    }
}
