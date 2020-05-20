using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Repositories
{
    public interface ICellRepository
    {
        public Task<bool> InitiliazeWorld(Guid Id, string Title); //Method used for initializing a new World, with cells 
    }
}
