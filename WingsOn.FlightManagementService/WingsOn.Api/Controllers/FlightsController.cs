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

        // GET: api/v1/flights/PZ696
        /// <summary>
        /// Gets a flight by the flight number.
        /// </summary>
        /// <param name="number">The flight's identifier.</param>
        /// <returns>
        /// Returns the instance of the <see cref="FlightViewModel"/> class.
        /// </returns>
        [HttpGet("{number}")]
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

            return Ok(_mapper.Map<FlightViewModel>(flight));
        }

        // GET: api/v1/flights/PZ696/passengers/male
        // GET: api/v1/flights/PZ696/passengers/female
        /// <summary>
        /// Gets a list of passenger for a particular flight and for particular gender.
        /// </summary>
        /// <param name="number">The number of the flight.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>
        /// Returns a list of instances of the <see cref="PersonViewModel"/> class.
        /// </returns>
        [HttpGet("{number}/passengers/{gender}")]
        public IActionResult GetPassengers(string number, GenderType gender)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                return BadRequest("The number of a flight is null or is empty string.");
            }

            var passengers = _flightService.GetPassengers(number, gender);
            return Ok(_mapper.Map<IEnumerable<PersonViewModel>>(passengers));
        }
    }
}