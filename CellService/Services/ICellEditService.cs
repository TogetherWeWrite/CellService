using CellService.Entities;
using CellService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CellService.Exceptions;

namespace CellService.Services
{
    public interface ICellEditService
    {
        /// <summary>
        /// Updates the color of one cell
        /// </summary>
        /// <param name="model">Contains the world id of which the cell and the chunk should take part</param>
        /// <param name="jwt">Contains the jwt token which contains which person is trying to edit the color</param>
        /// <returns></returns>
        /// <exception cref="CellDoesNotExistInThisWorldException"></exception>
        /// <exception cref="WorldDoesNotContainThisChunkException"></exception>
        public Task<Chunk> UpdateColor(UpdateCellColorModel model, string jwt);
    }
}
