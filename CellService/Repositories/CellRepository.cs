using CellService.Entities;
using CellService.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Repositories
{
    public class CellRepository : ICellRepository
    {
        public readonly IMongoCollection<World> _worlds;
        public CellRepository(ICellServiceDataStoreSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _worlds = database.GetCollection<World>(settings.CollectionName);
        }

    }
}
