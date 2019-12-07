using Microsoft.AspNetCore.Mvc;
using WingsOn.Services.Interfaces;
using WingsOn.Services.Models;

namespace WingsOn.Api.Controllers
{
    /// <summary>
    /// The persons controller.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonsController"/> class.
        /// </summary>
        /// <param name="personService"></param>
        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: api/v1/persons
        /// <summary>
        /// Gets all persons.
        /// </summary>
        /// <returns>
        /// Returns all persons.
        /// </returns>
        [HttpGet]
        public IActionResult Get()
        {
            var persons = _personService.GetAllPersons();
            return Ok(persons);
        }

        // GET: api/v1/persons/5
        /// <summary>
        /// Gets person by id.
        /// </summary>
        /// <param name="id">The persons's identifier.</param>
        /// <returns>
        /// Returns a person with provided identifier.
        /// </returns>
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
        /// <summary>
        /// Create a new person.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>
        /// Returns the person that has been created.
        /// </returns>
        [HttpPost]
        public IActionResult Post([FromBody] PersonModel person)
        {
            var result = _personService.CreatePerson(person);
            return Ok(result);
        }

        // PUT: api/v1/persons/5
        /// <summary>
        /// Updates an existing person or creates a new one.
        /// </summary>
        /// <param name="id">The person's identifier.</param>
        /// <param name="person">The person.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PersonModel person)
        {
            _personService.UpdatePerson(person);
            return Ok();
        }

        // DELETE: api/v1/persons/5
        /// <summary>
        /// Removes a person by provided id.
        /// </summary>
        /// <param name="id">The id of a person that should be removed.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.RemovePerson(id);
            return Ok();
        }
    }
}