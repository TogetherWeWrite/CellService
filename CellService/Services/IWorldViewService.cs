using CellService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exceptions;

namespace CellService.Services
{
    public interface IWorldViewService
    {
        /// <summary>
        /// Returns the world with cells
        /// </summary>
        /// <param name="id">The id of the world</param>
        /// <returns><see cref="WorldInitialLoadModel"/>Which contains the world with the middle cells</returns>
        /// <exception cref="WorldNotFoundException">When the world is not found</exception>
        Task<WorldInitialLoadModel> GetWorldWithMiddleChunk(Guid id);
        Task<LoadPartOfWorld> GetPartOfWorld(List<Guid> RemainingChunks);
    }
}
