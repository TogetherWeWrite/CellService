using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Entities
{
    public class Cell
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Color { get; set; } // Color in hex (#00abff)
    }
}
