using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CellService.Models;
using CellService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CellService.Controllers
{
    [Route("cell")]
    [ApiController]
    public class CellController : ControllerBase
    {
        private readonly ICellEditService _cellEditService;
        public CellController(ICellEditService cellEditService)
        {
            _cellEditService = cellEditService;
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UpdateCellColorModel model)
        {
            try
            {
                return Ok(await _cellEditService.UpdateColor(model));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}