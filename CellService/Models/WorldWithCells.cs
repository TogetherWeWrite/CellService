using CellService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Models
{
    public class WorldWithCells
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<List<Chunk>> grid { get; set; }
    }
}
