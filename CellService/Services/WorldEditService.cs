using CellService.Entities;
using CellService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Services
{
    public class WorldEditService : IWorldEditService
    {
        private readonly IWorldRepository _worldRepository;
        public WorldEditService(IWorldRepository worldRepository)
        {
            _worldRepository = worldRepository;
        }

        public async Task createWorld(Guid id, string titleWorld)
        {
            var world = new World
            {
                Id = id,
                Title = titleWorld,
                Cells = new List<List<Cell>>()
                { new List<Cell>()
                    {
                        new Cell
                        {
                            CellName = "Je Eerste Cell! [1,1]",
                            Color = "#55ff55",
                            InnerCells = null,
                            AttachedPages = new List<Page>(),
                            Id = new Guid()
                        }
                    }
                } //[1,1] initialize
            };
            await _worldRepository.InitiliazeWorld(world);
        }
    }
}
