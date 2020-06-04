using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CellService.Entities;
using CellService.Models;
using CellService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CellService.Controllers
{
    [Route("chunk")]
    [ApiController]
    public class ChunkController : ControllerBase
    {
        private readonly IChunkService _chunkService;
        public ChunkController(IChunkService chunkService)
        {
            _chunkService = chunkService;
        }
        [HttpPost]
        public async Task<ActionResult> CreateNewChunk(Guid worldId, CreateNewChunkModel model)
        {
            try
            {
                return Ok(await _chunkService.CreateNewChunk(worldId,model));
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            throw new NotImplementedException();
        }
    }
}