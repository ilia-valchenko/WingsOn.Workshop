using Microsoft.AspNetCore.Mvc;

namespace WingsOn.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: api/v1/persons
        [HttpGet]
        public IActionResult Get()
        {
            var persons = _personService.GetAllPersons();
            return Ok(persons);
        }

        // GET: api/v1/persons/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personService.GetPerson(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // POST: api/v1/persons
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            var result = _personService.CreatePerson(person);
            return Ok(result);
        }

        // PUT: api/v1/persons/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Person person)
        {
            _personService.UpdatePerson(person);
            return Ok();
        }

        // DELETE: api/v1/persons/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.RemovePerson(id);
            return Ok();
        }
    }
}