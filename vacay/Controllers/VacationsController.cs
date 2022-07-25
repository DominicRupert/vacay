using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vacay.Models;
using Microsoft.AspNetCore.Authorization;
using vacay.Services;
using CodeWorks.Auth0Provider;

namespace vacay.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacationsController : ControllerBase
    {
        private readonly VacationsService _vs;

        public VacationsController(VacationsService vs)
        {
            _vs = vs;
        }

        [HttpGet]
        public ActionResult<List<Vacation>> GetAll()
        {
            return _vs.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Vacation> GetById(int id)
        {
            return _vs.GetById(id);
        }
        
        [HttpPost]
        [Authorize]
        public async  Task<ActionResult<Vacation>> Create([FromBody] Vacation newVacation)
        {
            try{
            Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
            newVacation.CreatorId = userInfo.Id;
            Vacation vacayData = _vs.Create(newVacation);
            vacayData.Creator = userInfo;
            vacayData.CreatedAt = new DateTime();
            return Ok(newVacation);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}