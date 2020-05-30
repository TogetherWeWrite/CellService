using CellService.Entities;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Helpers
{
    public interface IChunkHelper
    {
        public Task<List<List<Cell>>> GetStandardChunkGrid(string name);
    }
}
