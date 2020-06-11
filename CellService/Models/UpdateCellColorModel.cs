using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Models
{
    public class UpdateCellColorModel
    {
        public Guid CellId { get; set; }
        public Guid WorldId { get; set; }
        public Guid ChunkId { get; set; }
        public string Color { get; set; }
    }
}
