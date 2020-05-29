using CellService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Services
{
    public interface IWorldViewService
    {
        Task<WorldWithCells> GetWorldWithCell(Guid id);
    }
}
