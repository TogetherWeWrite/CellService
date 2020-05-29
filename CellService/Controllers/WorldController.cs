using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CellService.Entities;
using CellService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CellService.Controllers
{
    [Route("world")]
    [ApiController]
    public class WorldController : ControllerBase
    {
        private readonly IWorldViewService _worldViewService;
        public WorldController(IWorldViewService worldViewService)
        {
            this._worldViewService = worldViewService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _worldViewService.GetWorldWithMiddleCells(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}