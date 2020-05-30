using CellService.Models;
using CellService.Repositories;
using Exceptions;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CellService.Entities;

namespace CellService.Services
{
    public class WorldViewService : IWorldViewService
    {
        private readonly IWorldRepository _worldRepository;
        private readonly IChunkRepository _chunkRepository;
        public WorldViewService(IWorldRepository worldRepository, IChunkRepository chunkRepository)
        {
            this._worldRepository = worldRepository;
            this._chunkRepository = chunkRepository;
        }

        public async Task<WorldWithCells> GetWorldWithMiddleChunk(Guid id)
        {
            var world = await _worldRepository.GetWorldWithCells(id);
            int meanHeightRounded = world.Grid.Count / 2;
            int meanWidthRounded = world.Grid[meanHeightRounded].Count / 2;
            var middleChunk = await _chunkRepository.Get(world.Grid[meanHeightRounded][meanWidthRounded]);
            if(world == null)
            {
                throw new WorldNotFoundException(id);
            }
            return new WorldWithCells
            {
                grid = new List<List<Chunk>>()
                {
                    new List<Chunk>()
                    {
                        middleChunk
                    }
                },
                Id = world.Id,
                Title = world.Title
            };
        }
    }
}
