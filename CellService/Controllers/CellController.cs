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
        [Authorize]
        public async Task<IActionResult> Put([FromBody]UpdateCellColorModel model, [FromHeader(Name ="Authorization")]string jwt)
        {
            try
            {
                return Ok(await _cellEditService.UpdateColor(model, jwt));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}