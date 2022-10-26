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
            this.context.Persons.Add(p);
            this.context.SaveChanges();
            // retorna o metodo http get show random person, cria um action result
            return CreatedAtAction(nameof(ShowPersonCount), new {id = p.Id},  p);
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

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(int id, Person personUpdate)
        {
            var person = this.context.Persons.Find(id);

            if (person == null)
            {
                return NotFound();
            }
            person.Name = personUpdate.Name;
            person.LastName = personUpdate.LastName;
            person.BirthDate = personUpdate.BirthDate;
            person.Sex = person.Sex;

            this.context.Update(person);
            context.SaveChanges();

            return Ok(person);
        }


        [HttpGet("Get All names {name}")]
        public IActionResult ShowPersonTOName(string name)
        {
            var personDatabase = this.context.Persons.Where(x => x.Name == name);

            if (personDatabase.Count() == 0)
            {
                return NoContent();
            }

            return Ok(personDatabase);
        }

        [HttpDelete("Deletar Person {id}")]
        public IActionResult DeletePerson(int id)
        {
            var personDatabase = this.context.Persons.Find(id);
            if (personDatabase == null)
            {
                return NotFound();
            }
            this.context.Persons.Remove(personDatabase);
            this.context.SaveChanges();

            return Ok($"Usuário {personDatabase.Name} {personDatabase.LastName} removido com sucesso");
        }
    }
}