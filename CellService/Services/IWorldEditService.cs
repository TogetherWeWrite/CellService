using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Services
{
    public interface IWorldEditService
    {
        /// <summary>
        /// Method used for creating a new world with its starter chunk
        /// </summary>
        /// <param name="id">the id of the world which must be the same as the one in the worldservice</param>
        /// <param name="titleWorld">The title of the world</param>
        /// <returns></returns>
        Task createWorld(Guid id, string titleWorld);
        /// <summary>
        /// Deletes the world and all the chunks that the world is made of
        /// </summary>
        /// <param name="id">The id of the world</param>
        /// <returns></returns>
        Task DeleteWorld(Guid id);
    }
}
