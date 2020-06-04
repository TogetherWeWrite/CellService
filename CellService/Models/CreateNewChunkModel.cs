using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Models
{
    public class CreateNewChunkModel
    {
        public string Name { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
    }
}
