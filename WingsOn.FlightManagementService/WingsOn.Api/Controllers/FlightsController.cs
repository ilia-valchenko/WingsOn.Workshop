using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Api.ViewModels;
using WingsOn.Core.Enums;
using WingsOn.Services.Interfaces;

namespace WingsOn.Api.Controllers
{
    /// <summary>
    /// The flights controller.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _flightService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightsController"/> class.
        /// </summary>
        /// <param name="flightService">The flight service.</param>
        /// <param name="mapper">The mapper.</param>
        public FlightsController(
            IFlightService flightService,
            IMapper mapper)
        {
            _flightService = flightService;
            _mapper = mapper;
        }

        // GET: api/v1/flights
        /// <summary>
        /// Gets all flights.
        /// </summary>
        /// <returns>
        /// Returns a collection of instances of the <see cref="FlightViewModel"/> class.
        /// </returns>
        [HttpGet]
        public IActionResult Get()
        {
            var flights = _flightService.GetAllFlights();
            return Ok(_mapper.Map<IEnumerable<FlightViewModel>>(flights));
        }

        // GET: api/v1/flights/5
        /// <summary>
        /// Gets a flight by id.
        /// </summary>
        /// <param name="id">The flight's identifier.</param>
        /// <returns>
        /// Returns the instance of the <see cref="FlightViewModel"/> class.
        /// </returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var flight = _flightService.GetFlight(id);

            if (flight == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<FlightViewModel>(flight));
        }

        // GET: api/v1/flights?number=PZ696
        /// <summary>
        /// Gets a flight by a flight number.
        /// </summary>
        /// <param name="number">The number of a flight.</param>
        /// <returns>
        /// Returns a collection of instances of the <see cref="FlightViewModel"/> class.
        /// </returns>
        /// <remarks>
        /// The collection will contain only one item as we cannot have flights with
        /// duplicated flight numbers.
        /// </remarks>
        [HttpGet]
        public IActionResult Get(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                return BadRequest("The number of a flight is null or is empty string.");
            }

            var flight = _flightService.GetFlight(number);

            if (flight == null)
            {
                return NotFound();
            }

            // TODO: We will return a collection instead of a single resource due to
            // URL format. Query parameters look like a filter. We should not confuse the user of this API.
            // Actually the collection will contain a single item.
            return Ok(new [] { _mapper.Map<FlightViewModel>(flight) });
        }

        // GET: api/v1/flights/12/passengers/male
        // GET: api/v1/flights/12/passengers/female
        /// <summary>
        /// Gets a list of passenger for a particular flight and for particular gender.
        /// </summary>
        /// <param name="id">The flight's identifier.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>
        /// Returns a list of instances of the <see cref="PersonViewModel"/> class.
        /// </returns>
        [HttpGet("{id}/passengers/{gender}")]
        public IActionResult GetPassengers(int id, GenderType gender)
        {
            if (id <= 0)
            {
                return BadRequest("The flight identifier is less than zero or equals to zero.");
            }

            var passengers = _flightService.GetPassengers(id, gender);
            return Ok(_mapper.Map<IEnumerable<PersonViewModel>>(passengers));
        }
    }
}