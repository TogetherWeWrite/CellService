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

        public async Task<bool> InitiliazeWorld(Guid Id, string Title)
        {
            var world = new World
            {
                Id = Id,
                Title = Title,
                Cells = new List<List<Cell>>()
                { new List<Cell>()
                    {
                        new Cell
                        {
                            CellName = "Je Eerste Cell! [1,1]",
                            Color = "#55ff55",
                            InnerCells = null,
                            AttachedPages = new List<Page>(),
                            Id = new Guid()
                        }
                    }
                } //[1,1] initialize
            };
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

        public Task<bool> EditRightsWorld(Guid id, EditRight obj)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteWorld(Guid id)
        {
            await _worlds.DeleteOneAsync(world => world.Id == id);
            return true;
        }
    }
}