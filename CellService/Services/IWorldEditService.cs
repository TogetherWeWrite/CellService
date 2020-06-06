using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Services
{
    public interface IWorldEditService
    {
        Task createWorld(Guid id, string titleWorld);
    }
}
