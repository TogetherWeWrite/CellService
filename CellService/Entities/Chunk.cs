using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Entities
{
    public class Chunk
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<List<Cell>> Cells { get; set; }
        public List<Page> AttachedPages { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

    }
}
