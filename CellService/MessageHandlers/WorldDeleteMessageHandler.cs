using CellService.MqMessages;
using CellService.Services;
using MessageBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CellService.MessageHandlers
{
    public class WorldDeleteMessageHandler : IMessageHandler<WorldDeleteMessage>
    {
        private readonly IWorldEditService _worldEditService;
        public WorldDeleteMessageHandler(IWorldEditService worldEditService)
        {
            _worldEditService = worldEditService;
        }
        public Task HandleMessageAsync(string messageType, WorldDeleteMessage sendable)
        {
            _worldEditService.DeleteWorld(sendable.Id);
            return Task.CompletedTask;
        }
        public Task HandleMessageAsync(string messageType, byte[] obj)
        {
            return HandleMessageAsync(messageType, JsonSerializer.Deserialize<WorldDeleteMessage>((ReadOnlySpan<byte>)obj, (JsonSerializerOptions)null));
        }
    }
}
