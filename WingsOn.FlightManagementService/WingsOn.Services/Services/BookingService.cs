using System;
using System.Threading.Tasks;
using AutoMapper;
using WingsOn.Core.Exceptions;
using WingsOn.Dal.Interfaces;
using WingsOn.Domain;
using WingsOn.Services.Infrastructure.Interfaces;
using WingsOn.Services.Interfaces;
using WingsOn.Services.Models;

namespace WingsOn.Services.Services
{
    /// <summary>
    /// The booking service.
    /// </summary>
    public sealed class BookingService : IBookingService
    {
        private static readonly object _lockObject = new object();

        private readonly IRepository<Booking> _bookingRepository;
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<Flight> _flightRepository;
        private readonly IPersonService _personService;
        private readonly IBookingNumberGenerator _bookingNumberGenerator;
        private readonly IResourceIdGenerator _resourceIdGenerator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingService"/> class.
        /// </summary>
        /// <param name="bookingRepository">The booking repository.</param>
        /// <param name="personRepository">The person repository.</param>
        /// <param name="flightRepository">The flight repository.</param>
        /// <param name="personService">The person service.</param>
        /// <param name="bookingNumberGenerator">The booking number generator.</param>
        /// <param name="resourceIdGenerator">The resource id generator.</param>
        /// <param name="mapper">The mapper.</param>
        public BookingService(
            IRepository<Booking> bookingRepository,
            IRepository<Person> personRepository,
            IRepository<Flight> flightRepository,
            IPersonService personService,
            IBookingNumberGenerator bookingNumberGenerator,
            IResourceIdGenerator resourceIdGenerator,
            IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _personRepository = personRepository;
            _flightRepository = flightRepository;
            _personService = personService;
            _bookingNumberGenerator = bookingNumberGenerator;
            _resourceIdGenerator = resourceIdGenerator;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<BookingModel> CreateBookingAsync(string flightNumber, PersonModel passenger)
        {
            if (string.IsNullOrWhiteSpace(flightNumber))
            {
                throw new ArgumentException("The number of the flight is invalid.");
            }

            if (passenger == null)
            {
                throw new ArgumentNullException(nameof(passenger));
            }

            var flight = await _flightRepository
                .FindAsync(f => string.Equals(f.Number, flightNumber, StringComparison.OrdinalIgnoreCase));

            if (flight == null)
            {
                throw new ResourceNotFoundException("The flight with provided flight number does not exist.");
            }

            var person = await _personRepository.GetAsync(passenger.Id);

            if (person == null)
            {
                passenger = await _personService.CreatePersonAsync(passenger);
            }

            var booking = new BookingModel
            {
                Id = GenerateNextBookingId(),
                Number = _bookingNumberGenerator.GenerateBookingNumber(),
                Flight = _mapper.Map<FlightModel>(flight),
                Customer = passenger,
                Passengers = new[] { passenger },
                DateBooking = DateTime.UtcNow
            };

            await _bookingRepository.SaveAsync(_mapper.Map<Booking>(booking));
            return booking;
        }

        /// <summary>
        /// Generates the next person's id.
        /// </summary>
        /// <returns>
        /// Returns the next person's id.
        /// </returns>
        private int GenerateNextBookingId()
        {
            lock (_lockObject)
            {
                var bookings = _bookingRepository.GetAll();
                return _resourceIdGenerator.GenerateResourceId(bookings);
            }
        }
    }
}