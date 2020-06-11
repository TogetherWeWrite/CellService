using CellService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Repositories
{
    public interface IChunkRepository
    {
        // <summary>
        /// Will get Worlds whcih have the search title max of 25.
        /// </summary>
        /// <param name="searchWord">If title has this within its name than it will be included in the result</param>
        /// <returns>List of worlds which contain the searchWord.</returns>
        Task<Chunk> Get(Guid id);
        Task<Chunk> Get(string Title);
        Task<Chunk> Update(Guid id, Chunk newChunk);
        Task<Chunk> Create(Chunk world);
        Task<List<Chunk>> Get(List<Guid> toGet);
        Task UpdateChunkTitle(Guid id, string newTitle);
        Task UpdateCell(Guid chunkId, Guid cellId, Cell newCell);
        Task Remove(Guid id);
    }
}
