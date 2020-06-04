using CellService.Entities;
using CellService.Helpers;
using CellService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Services
{
    public class WorldEditService : IWorldEditService
    {
        private readonly IWorldRepository _worldRepository;
        private readonly IChunkRepository _chunkRepository;
        private readonly IChunkHelper _chunkHelper;
        public WorldEditService(IWorldRepository worldRepository, IChunkHelper chunkHelper, IChunkRepository chunkRepository)
        {
            this._chunkHelper = chunkHelper;
            _worldRepository = worldRepository;
            _chunkRepository = chunkRepository;
        }

        public async Task createWorld(Guid id, string titleWorld)
        {
            var cells = await _chunkHelper.GetStandardChunkGrid(titleWorld);
            var chunk = new Chunk { Id = new Guid(), Cells = cells, Name ="Start Chunk"+" "+ titleWorld, AttachedPages = new List<Page>(), PosX=0,PosY=0};
            await _chunkRepository.Create(chunk);
            //TOOD saveChunk.
            var world = new World
            {
                Id = id,
                Title = titleWorld,
                Grid = new List<Guid>()
                { 
                        chunk.Id  
                } //[1,1] initialize
            };
            await _worldRepository.CreateWorld(world);
        }
    }
}
