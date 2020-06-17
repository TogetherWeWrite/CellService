using CellService.Entities;
using CellService.Helpers;
using CellService.Models;
using CellService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Services
{
    public class ChunkService : IChunkService
    {
        private readonly IChunkRepository _chunkRepository;
        private readonly IWorldRepository _worldRepository;
        private readonly IChunkHelper _chunkHelper;
        private readonly IAuthenticationHelper _authenticationHelper;
        public ChunkService(IChunkRepository chunkRepository, IChunkHelper chunkhelper,IWorldRepository worldRepository, IAuthenticationHelper authenticationHelper)
        {
            _chunkRepository = chunkRepository;
            _chunkHelper = chunkhelper;
            _worldRepository = worldRepository;
            _authenticationHelper = authenticationHelper;
        }

        public async Task<Chunk> CreateNewChunk(CreateNewChunkModel model, string jwt)
        {
            //todo authorization
            var chunk = new Chunk() {
                Cells = await _chunkHelper.GetStandardChunkGrid(model.Name),
                Id = Guid.NewGuid(),
                Name = model.Name,
                AttachedPages = new List<Page>(),
                PosX = model.PosX,
                PosY = model.PosY
            };
            var world = await _worldRepository.Get(model.WorldId);
            world.Grid.Add(chunk.Id);
            await _worldRepository.Update(world.Id, world);
            var createdChunk=  await _chunkRepository.Create(chunk);
            return createdChunk;
        }

        
    }
}
