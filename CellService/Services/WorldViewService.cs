using CellService.Models;
using CellService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Services
{
    public class WorldViewService : IWorldViewService
    {
        private readonly IWorldRepository _worldRepository;
        public WorldViewService(IWorldRepository worldRepository)
        {
            this._worldRepository = worldRepository;
        }

        public async Task<WorldWithCells> GetWorldWithCell(Guid id)
        {
            throw new NotImplementedException();//TODO implement
        }
    }
}
