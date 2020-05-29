using CellService.Models;
using CellService.Repositories;
using Exceptions;
using System;
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

        public async Task<WorldWithCells> GetWorldWithMiddleCells(Guid id)
        {
            var world = await _worldRepository.GetWorldWithCells(id);
            if(world == null)
            {
                throw new WorldNotFoundException(id);
            }
            return new WorldWithCells
            {
                cells = world.Cells,
                Id = world.Id,
                Title = world.Title
            };
        }
    }
}
