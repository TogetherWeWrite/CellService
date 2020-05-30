using CellService.Models;
using System;
using System.Threading.Tasks;
using Exceptions;
using CellService.Entities;

namespace CellService.Repositories
{
    public interface IWorldRepository //Repository used for editing world information. This will be called by the message queue.
    {
        public Task<bool> CreateWorld(World world); //Method used for initializing a new World, with cells 
        /// <summary>
        /// Method used for changed the world title in the database.
        /// </summary>
        /// <param name="id">The id Of the world you wish to change the title from</param>
        /// <param name="newTitle">The new title of the world</param>
        /// <returns></returns>
        /// <exception cref="WorldNotFoundException"></exception>
        public Task<bool> EditWorldTitle(Guid id, string newTitle);//Method used only for editing the title.
        public Task<bool> DeleteWorld(Guid id);

        public Task<World> GetWorldWithCells(Guid id);
    }

}