﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Api.ViewModels;
using WingsOn.Core.Enums;
using WingsOn.Services.Interfaces;
using WingsOn.Services.Models;

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
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightsController"/> class.
        /// </summary>
        /// <param name="flightService">The flight service.</param>
        /// <param name="bookingService">The booking service.</param>
        /// <param name="mapper">The mapper.</param>
        public FlightsController(
            IFlightService flightService,
            IBookingService bookingService,
            IMapper mapper)
        {
            _flightService = flightService;
            _bookingService = bookingService;
            _mapper = mapper;
        }

        // GET: api/v1/flights
        /// <summary>
        /// Gets all flights asynchronous.
        /// </summary>
        /// <returns>
        /// Returns a collection of instances of the <see cref="FlightViewModel"/> class.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var flights = await _flightService.GetAllFlightsAsync();
            return Ok(_mapper.Map<IEnumerable<FlightViewModel>>(flights));
        }

        // GET: api/v1/flights/PZ696
        /// <summary>
        /// Gets a flight by the flight number asynchronous.
        /// </summary>
        /// <param name="number">The flight's identifier.</param>
        /// <returns>
        /// Returns the instance of the <see cref="FlightViewModel"/> class.
        /// </returns>
        [HttpGet("{number}")]
        public async Task<IActionResult> GetAsync(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                return BadRequest("The number of a flight is null or is empty string.");
            }

            var flight = await _flightService.GetFlightAsync(number);

            if (flight == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<FlightViewModel>(flight));
        }

        // GET: api/v1/flights/PZ696/passengers/male
        // GET: api/v1/flights/PZ696/passengers/female
        /// <summary>
        /// Gets a list of passenger for a particular flight and for particular gender asynchronous.
        /// </summary>
        /// <param name="number">The number of the flight.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>
        /// Returns a list of instances of the <see cref="PersonViewModel"/> class.
        /// </returns>
        [HttpGet("{number}/passengers/{gender}")]
        public async Task<IActionResult> GetPassengersAsync(string number, GenderType gender)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                return BadRequest("The number of a flight is null or is empty string.");
            }

            var passengers = await _flightService.GetPassengersAsync(number, gender);
            return Ok(_mapper.Map<IEnumerable<PersonViewModel>>(passengers));
        }

        // POST: api/v1/flights/PZ696/passengers
        /// <summary>
        /// Creates a new booking of an existing flight for a new passenger asynchronous.
        /// </summary>
        /// <param name="number">The number of the flight.</param>
        /// <param name="person">The passenger.</param>
        /// <returns>
        /// Returns an instance of the <see cref="BookingViewModel"/> class.
        /// </returns>
        [HttpPost("{number}/passengers")]
        public async Task<IActionResult> CreateBookingAsync(string number, [FromBody] PersonViewModel person)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                return BadRequest("The flight number is invalid.");
            }

            if (person == null)
            {
                return BadRequest("The person is missed.");
            }

            var booking = await _bookingService.CreateBookingAsync(number, _mapper.Map<PersonModel>(person));
            return Ok(_mapper.Map<BookingViewModel>(booking));
        }
    }
}