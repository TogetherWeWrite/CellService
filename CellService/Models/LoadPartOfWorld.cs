using CellService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Models
{
    public class LoadPartOfWorld
    {
        public List<Guid> RemainingChunks { get; set; }
        public List<Chunk> Chunks { get; set; }
        public bool DoneLoading { get; set; }
    }
}
