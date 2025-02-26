using Microsoft.AspNetCore.Mvc;
using TestWebApi.Models;

namespace TestWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private static List<Persona> personas = new List<Persona>(new List<Persona>
            {
                new Persona { Id = 1, Nombre = "Juan", Apellido = "Pérez", Email = "juan.perez@example.com", Telefono = "123456789" },
                new Persona { Id = 2, Nombre = "María", Apellido = "Gómez", Email = "maria.gomez@example.com", Telefono = "987654321" },
                new Persona { Id = 3, Nombre = "Carlos", Apellido = "López", Email = "carlos.lopez@example.com", Telefono = "456123789" },
                new Persona { Id = 4, Nombre = "Ana", Apellido = "Martínez", Email = "ana.martinez@example.com", Telefono = "789456123" },
                new Persona { Id = 5, Nombre = "Luis", Apellido = "García", Email = "luis.garcia@example.com", Telefono = "321654987" },
                new Persona { Id = 6, Nombre = "Laura", Apellido = "Hernández", Email = "laura.hernandez@example.com", Telefono = "654987321" },
                new Persona { Id = 7, Nombre = "Pedro", Apellido = "Sánchez", Email = "pedro.sanchez@example.com", Telefono = "147258369" },
                new Persona { Id = 8, Nombre = "Sofía", Apellido = "Ramírez", Email = "sofia.ramirez@example.com", Telefono = "369258147" },
                new Persona { Id = 9, Nombre = "Miguel", Apellido = "Torres", Email = "miguel.torres@example.com", Telefono = "258369147" },
                new Persona { Id = 10, Nombre = "Lucía", Apellido = "Flores", Email = "lucia.flores@example.com", Telefono = "147369258" }
            });
        public PersonasController()
        {
        }

        [HttpGet]
        public ActionResult<IEnumerable<Persona>> Get()
        {
            return Ok(personas);
        }

        //[HttpGet("{id}")]
        //public ActionResult<Persona> Get(int id)
        //{
        //    var persona = personas.Find(p => p.Id == id);
        //    if (persona == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(persona);
        //}

        [HttpPost]
        public ActionResult<Persona> Post(Persona persona)
        {
            personas.Add(persona);
            return CreatedAtAction(nameof(Get), new { id = persona.Id }, persona);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Persona updatedPersona)
        {
            var persona = personas.Find(p => p.Id == id);
            if (persona == null)
            {
                return NotFound("La persona no existe.");
            }
            persona.Nombre = updatedPersona.Nombre;
            persona.Apellido = updatedPersona.Apellido;
            persona.Email = updatedPersona.Email;
            persona.Telefono = updatedPersona.Telefono;
            return NoContent();
        }

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var persona = personas.Find(p => p.Id == id);
        //    if (persona == null)
        //    {
        //        return NotFound("La persona no existe.");
        //    }
        //    personas.Remove(persona);
        //    return NoContent();
        //}
    }
}
