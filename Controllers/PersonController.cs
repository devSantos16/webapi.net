using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.net.Context;
using webapi.net.models;

namespace webapi.net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PersonContext context;

        public PersonController(PersonContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult Create(Person p)
        {
            this.context.Add(p);
            this.context.SaveChanges();
            return Ok(p);
        }

        [HttpGet("Show random Person")]
        public IActionResult ShowRandomPerson()
        {
            return Ok(new RandomPerson(this.context));
        }

        [HttpGet("Show Person Count")]
        public IActionResult ShowPersonCount()
        {
            var c = this.context.Persons.Count();
            return Ok($"Numero total de Pessoas no banco de dados é: {c}");
        }



        [HttpGet("Show Person To ID")]
        public IActionResult ShowPersonTOID(int id)
        {
            if (this.context.Persons.Find(id) == null)
            {
                return NotFound();
            }
            return Ok(this.context.Persons.Find(id));
        }
    }
}