using System;
using System.Globalization;
using System.Linq;
using WingsOn.Dal.Interfaces;
using WingsOn.Domain;

namespace WingsOn.Dal.Repositories
{
    /// <summary>
    /// The booking repository.
    /// </summary>
    public sealed class BookingRepository : RepositoryBase<Booking>
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<Flight> _flightRepository;
        private readonly CultureInfo _cultureInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingRepository"/> class.
        /// </summary>
        /// <param name="personRepository">The person repository.</param>
        /// <param name="flightRepository">The flight repository.</param>
        public BookingRepository(
            IRepository<Person> personRepository,
            IRepository<Flight> flightRepository)
        {

            _personRepository = personRepository;
            _flightRepository = flightRepository;

            // TODO: Put culture info in a config file.
            // TODO: Implement configuration provider.
            _cultureInfo = new CultureInfo("nl-NL");

            Repository.AddRange(new[]
            {
                new Booking
                {
                    Id = 55,
                    Number = "WO-291470",
                    Customer = _personRepository.GetAll().Single(p => p.Name == "Branden Johnston"),
                    DateBooking = DateTime.Parse("03/03/2006 14:30", _cultureInfo),
                    Flight = _flightRepository.GetAll().Single(f => f.Number == "BB768"),
                    Passengers = new []
                    {
                        _personRepository.GetAll().Single(p => p.Name == "Branden Johnston")
                    }
                },
                new Booking
                {
                    Id = 83,
                    Number = "WO-151277",
                    Customer = _personRepository.GetAll().Single(p => p.Name == "Debra Lang"),
                    DateBooking = DateTime.Parse("12/02/2000 12:55", _cultureInfo),
                    Flight = _flightRepository.GetAll().Single(f => f.Number == "PZ696"),
                    Passengers = new []
                    {
                        _personRepository.GetAll().Single(p => p.Name == "Claire Stephens"),
                        _personRepository.GetAll().Single(p => p.Name == "Kendall Velazquez"),
                        _personRepository.GetAll().Single(p => p.Name == "Zenia Stout")
                    }
                },
                new Booking
                {
                    Id = 34,
                    Number = "WO-694142",
                    Customer = _personRepository.GetAll().Single(p => p.Name == "Kathy Morgan"),
                    DateBooking = DateTime.Parse("13/02/2000 16:37", _cultureInfo),
                    Flight = _flightRepository.GetAll().Single(f => f.Number == "PZ696"),
                    Passengers = new []
                    {
                        _personRepository.GetAll().Single(p => p.Name == "Kathy Morgan"),
                        _personRepository.GetAll().Single(p => p.Name == "Melissa Long")
                    }
                },
                new Booking
                {
                    Id = 90,
                    Number = "WO-139716",
                    Customer = _personRepository.GetAll().Single(p => p.Name == "Bonnie Rice"),
                    DateBooking = DateTime.Parse("03/12/2011 16:50", _cultureInfo),
                    Flight = _flightRepository.GetAll().Single(f => f.Number == "BB124"),
                    Passengers = new []
                    {
                        _personRepository.GetAll().Single(p => p.Name == "Bonnie Rice"),
                        _personRepository.GetAll().Single(p => p.Name == "Louise Harper")
                    }
                }
            });
        }
    }
}