using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodeWorks.Auth0Provider;
using vacay.Models;
using vacay.Services;
using Microsoft.AspNetCore.Authorization;

namespace vacay.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CruisesController : ControllerBase
    {

        private readonly CruisesService _cs;
        public CruisesController(CruisesService cs)
        {
            _cs = cs;
        }

        [HttpPost]
        public async Task<ActionResult<Cruise>> Create([FromBody] Cruise newCruise)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                newCruise.AccountId = userInfo.Id;
                Cruise cruiseData = _cs.Create(newCruise);
           
                return Ok(newCruise);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        
    }
}