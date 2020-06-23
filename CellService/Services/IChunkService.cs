using CellService.Entities;
using CellService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Services
{
    public interface IChunkService
    {
        Task<Chunk> CreateNewChunk(CreateNewChunkModel model, string jwt);
    }
}
