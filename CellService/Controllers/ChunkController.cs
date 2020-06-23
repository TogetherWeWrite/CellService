using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CellService.Entities;
using CellService.Models;
using CellService.Services;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> CreateNewChunk(CreateNewChunkModel model, [FromHeader(Name = "Authorization")]string jwt)
        {
            try
            {
                return Ok(await _chunkService.CreateNewChunk(model,jwt));
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            throw new NotImplementedException();
        }
    }
}