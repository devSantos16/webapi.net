using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.net.models;
using webapi.net;

namespace webapi.net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("Apresentar")]
        public IActionResult Apresentar()
        {
            return Ok(new RandomPerson());
        }
    }
}