using CellService.Models;
using CellService.Repositories;
using Exceptions;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CellService.Entities;
using MongoDB.Bson.IO;

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

        public async Task<LoadPartOfWorld> GetPartOfWorld(List<Guid> RemainingChunks)
        {
            int toGetAmount = 40;
            int remaininglenght = RemainingChunks.Count;
            if(remaininglenght <= 40)
            {
                toGetAmount = remaininglenght;
            }
            List<Guid> toGet = RemainingChunks.GetRange(0, toGetAmount);
            RemainingChunks.RemoveRange(0, toGetAmount);
            var chunks = await _chunkRepository.Get(toGet);
            bool doneloading = false;
            if(RemainingChunks.Count == 0)
            {
                doneloading = true;
            }
            return new LoadPartOfWorld { Chunks = chunks, RemainingChunks = RemainingChunks, DoneLoading=doneloading };
        }

        public async Task<WorldInitialLoadModel> GetWorldWithMiddleChunk(Guid id)
        {
            var world = await _worldRepository.GetWorldWithCells(id);
            var remainingChunks = world.Grid;
            var middleChunk = await _chunkRepository.Get(world.Grid[0]);
            remainingChunks.RemoveRange(0, 1);
            if (world == null)
            {
                throw new WorldNotFoundException(id);
            }
            return new WorldInitialLoadModel
            {
                Grid = new List<Chunk>()
                {
                    middleChunk
                },
                Id = world.Id,
                Title = world.Title,
                RemainingChunks = remainingChunks
            };
        }
    }
}
