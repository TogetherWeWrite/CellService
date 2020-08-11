using CellService.Entities;
using CellService.Exceptions;
using CellService.Helpers;
using CellService.Models;
using CellService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellService.Services
{
    public class CellEditService : ICellEditService
    {
        private readonly IChunkRepository _chunkRepository;
        private readonly IWorldRepository _worldRepository;
        private readonly IAuthenticationHelper _authenticationHelper;
        public CellEditService(IChunkRepository chunkRepository, IWorldRepository worldRepository, IAuthenticationHelper authenticationHelper)
        {
            _chunkRepository = chunkRepository;
            _worldRepository = worldRepository;
            _authenticationHelper = authenticationHelper;
        }
        public async Task<Chunk> UpdateColor(UpdateCellColorModel model, string jwt)
        {
            var world = await _worldRepository.GetWorldWithCells(model.WorldId);
            //TODO rights of this worlds.
            if (world.Grid.Contains(model.ChunkId))
            {
                var chunk = await _chunkRepository.Get(model.ChunkId);
                //int y = 0;
                //int x = 0;
                //bool cellExistInChunk = false; //bool to check if found.
                //foreach (var cells in chunk.Cells)//Loop through 2d list to get to check if cell is correct and the location of the cell with y and x;
                //{
                //    x = 0;
                //    foreach (var cell in cells)
                //    {
                //        if(cell.Id == model.CellId)
                //        {
                //            cellExistInChunk = true;
                //            break;
                //        }
                //        x++;
                //    }
                //    if (cellExistInChunk)
                //    {
                //        break;
                //    }
                //    y++;
                //}
                //if (cellExistInChunk)
                //{
                //    chunk.Cells[y][x].Color = model.Color;
                //    return await _chunkRepository.Update(chunk.Id,chunk);
                //}
                //else
                //{
                //    throw new CellDoesNotExistInThisWorldException(world.Title);
                //}
                chunk.Cells[model.PosY][model.PosX].Color = model.Color;
                return await _chunkRepository.Update(chunk.Id, chunk);
            }
            else
            {
                throw new WorldDoesNotContainThisChunkException(world.Title);
            }
        }
    }
}
