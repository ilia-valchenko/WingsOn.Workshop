using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Api.ViewModels;
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
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonsController"/> class.
        /// </summary>
        /// <param name="personService"></param>
        /// <param name="mapper">The mapper.</param>
        public PersonsController(
            IPersonService personService,
            IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        // GET: api/v1/persons
        /// <summary>
        /// Gets all persons asynchronous.
        /// </summary>
        /// <returns>
        /// Returns all persons.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var persons = await _personService.GetAllPersonsAsync();
            return Ok(_mapper.Map<IEnumerable<PersonViewModel>>(persons));
        }

        // GET: api/v1/persons/5
        /// <summary>
        /// Gets person by id asynchronous.
        /// </summary>
        /// <param name="id">The persons's identifier.</param>
        /// <returns>
        /// Returns a person with provided identifier.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var person = await _personService.GetPersonAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PersonViewModel>(person));
        }

        // POST: api/v1/persons
        /// <summary>
        /// Create a new person asynchronous.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>
        /// Returns the person that has been created.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PersonViewModel person)
        {
            var result = await _personService.CreatePersonAsync(_mapper.Map<PersonModel>(person));
            return Ok(_mapper.Map<PersonViewModel>(result));
        }

        // PUT: api/v1/persons/5
        /// <summary>
        /// Updates an existing person or creates a new one asynchronous.
        /// </summary>
        /// <param name="id">The person's identifier.</param>
        /// <param name="person">The person.</param>
        /// <returns>
        /// Returns HTTP 204 No Content if the person was successfully updated.
        /// </returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UpdatePersonViewModel person)
        {
            var updatedPerson = _mapper.Map<PersonModel>(person);
            updatedPerson.Id = id;
            await _personService.UpdatePersonAsync(updatedPerson);
            return NoContent();
        }

        // DELETE: api/v1/persons/5
        /// <summary>
        /// Removes a person by provided id asynchronous.
        /// </summary>
        /// <param name="id">The id of a person that should be removed.</param>
        /// <returns>
        /// Returns HTTP 204 No Content if the person was successfully removed.
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _personService.RemovePersonAsync(id);
            return NoContent();
        }
    }
}