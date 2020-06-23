using CellService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Helpers
{
    public class ChunkHelper : IChunkHelper
    {
        public async Task<List<List<Cell>>> GetStandardChunkGrid(string name)
        {
            var cells = new List<List<Cell>>();
            for(int i = 0; i<16; i++)
            {
                cells.Add(new List<Cell>());
                for(int j =0; j<16; j++)
                {
                    cells[i].Add(new Cell() { Color = "#ffffff"});
                }
            }
            return cells;
        }
    }
}
