using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vacay.Models;
using vacay.Interfaces;
using Microsoft.AspNetCore.Authorization;
using vacay.Services;

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
        
    }
}