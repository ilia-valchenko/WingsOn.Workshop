using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WingsOn.Core.Enums;
using WingsOn.Core.Exceptions;
using WingsOn.Dal.Interfaces;
using WingsOn.Domain;
using WingsOn.Services.Interfaces;
using WingsOn.Services.Models;

namespace WingsOn.Services.Services
{
    /// <summary>
    /// The flight service.
    /// </summary>
    public sealed class FlightService : IFlightService
    {
        private readonly IRepository<Flight> _flightRepository;
        private readonly IRepository<Booking> _bookingRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightService"/> class.
        /// </summary>
        /// <param name="flightRepository">The flight repository.</param>
        /// <param name="bookingRepository">The booking repository.</param>
        /// <param name="mapper">The mapper.</param>
        public FlightService(
            IRepository<Flight> flightRepository,
            IRepository<Booking> bookingRepository,
            IMapper mapper)
        {
            _flightRepository = flightRepository;
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<FlightModel>> GetAllFlightsAsync()
        {
            var flights = await _flightRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FlightModel>>(flights);
        }

        /// <inheritdoc />
        public async Task<FlightModel> GetFlightAsync(string flightNumber)
        {
            if (string.IsNullOrWhiteSpace(flightNumber))
            {
                throw new ArgumentException("The number of the flight is not valid.");
            }

            var flight = await _flightRepository.FindAsync(f => string.Equals(f.Number, flightNumber, StringComparison.OrdinalIgnoreCase));
            return _mapper.Map<FlightModel>(flight);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<PersonModel>> GetPassengersAsync(string flightNumber, GenderType gender)
        {
            if (string.IsNullOrWhiteSpace(flightNumber))
            {
                throw new ArgumentException("The number of the flight is not valid.");
            }

            var flight = await _flightRepository.FindAsync(f => string.Equals(f.Number, flightNumber, StringComparison.OrdinalIgnoreCase));

            if (flight == null)
            {
                throw new ResourceNotFoundException("The flight with provided flight number does not exist.");
            }

            var bookings = await _bookingRepository.FindAllAsync(b =>
                string.Equals(b.Flight?.Number, flightNumber, StringComparison.OrdinalIgnoreCase));

            if (bookings == null)
            {
                return Enumerable.Empty<PersonModel>();
            }

            var passengers = new List<Person>();

            foreach (var booking in bookings)
            {
                if (booking.Passengers != null && booking.Passengers.Any())
                {
                    passengers.AddRange(booking.Passengers);
                }
            }

            var filteredPassengers = passengers.Where(p => p.Gender == gender);
            return _mapper.Map<IEnumerable<PersonModel>>(filteredPassengers);
        }
    }
}