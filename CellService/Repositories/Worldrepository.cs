using CellService.Entities;
using CellService.Models;
using CellService.Settings;
using Exceptions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CellService.Repositories
{
    public class Worldrepository : IWorldRepository
    {
        public readonly IMongoCollection<World> _worlds;
        public Worldrepository(ICellServiceDataStoreSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _worlds = database.GetCollection<World>(settings.CollectionName);
        }
        public async Task<World> Get(Guid id)
        {
            return await _worlds.Find(world => world.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> CreateWorld(World world)
        {
            await _worlds.InsertOneAsync(world);
            return true;
        }

        public async Task<bool> EditWorldTitle(Guid id, string Title)
        {
            var world = await _worlds.Find(world => world.Id == id).FirstOrDefaultAsync();
            world.Title = Title;
            if(world == null)
            {
                throw new WorldNotFoundException(id);
            }
            await _worlds.ReplaceOneAsync(w => w.Id == id, world);
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteWorld(Guid id)
        {
            await _worlds.DeleteOneAsync(world => world.Id == id);
            return true;
        }

        public async Task<World> GetWorldWithCells(Guid id)
        {
            return await _worlds.Find(world => world.Id == id).FirstOrDefaultAsync();
        }

        public async Task<World> Update(Guid id, World updatedWorld)
        {
            await _worlds.ReplaceOneAsync(world => world.Id == id, updatedWorld);
            return updatedWorld;
        }
    }
}