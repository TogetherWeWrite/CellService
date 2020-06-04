using CellService.Entities;
using CellService.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Repositories
{
    public class ChunkRepository : IChunkRepository
    {
        public readonly IMongoCollection<Chunk> _chunks;
        public ChunkRepository(ICellServiceDataStoreSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _chunks = database.GetCollection<Chunk>(settings.ChunkCollectionName);
        }

        public async Task<Chunk> Create(Chunk chunk)
        {
            await _chunks.InsertOneAsync(chunk);
            return chunk;
        }

        public async Task<Chunk> Get(Guid id)
        {
            return await _chunks.Find(chunk => chunk.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Chunk> Get(string name)
        {
            return await _chunks.Find(chunk => chunk.Name == name).FirstOrDefaultAsync();
        }

        public async Task<List<Chunk>> Get(List<Guid> toGet)
        {
            return await _chunks.Find(chunk => toGet.Contains(chunk.Id)).ToListAsync();
        }

        public async Task Remove(Guid id)
        {
            await _chunks.DeleteOneAsync(chunk => chunk.Id == id);
        }

        public async Task UpdateCell(Guid chunkId, Guid cellId, Cell newCell)
        {
            var curchunk = await Get(chunkId);
            int indexlist = 0;
            int indexInList = 0;
            foreach (var list in curchunk.Cells)
            {
                foreach (var cell in list)
                {
                    indexInList = 0;
                    if (cell.Id == cellId)
                    {
                        return;//Get out list
                    }
                    indexInList++;
                }
                indexlist++;
            }
            curchunk.Cells[indexlist][indexInList] = newCell;
            await _chunks.ReplaceOneAsync(chunk => chunk.Id == chunkId, curchunk);
        }

        public async Task UpdateChunkTitle(Guid id, string newName)
        {
            var newchunk = await Get(id);
            newchunk.Name = newName;
            await _chunks.ReplaceOneAsync(chunk => chunk.Id == id, newchunk);
        }
    }
}
