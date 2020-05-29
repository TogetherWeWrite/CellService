using CellService.MqMessages;
using CellService.Repositories;
using MessageBroker;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.MessageHandlers
{
    public class WorldMessageHandler : IMessageHandler<WorldRegisterMessage>
    {
        private IWorldRepository _worldRepository;

        public WorldMessageHandler(IWorldRepository worldRepository)
        {
            _worldRepository = worldRepository;
        }

        public Task HandleMessageAsync(string messageType, WorldRegisterMessage sendable)
        {

            return Task.CompletedTask;
        }

        public Task HandleMessageAsync(string messageType, byte[] obj)
        {
            return HandleMessageAsync(messageType, JsonSerializer.Deserialize<WorldRegisterMessage>((ReadOnlySpan<byte>)obj, (JsonSerializerOptions)null));
        }
    }
}
