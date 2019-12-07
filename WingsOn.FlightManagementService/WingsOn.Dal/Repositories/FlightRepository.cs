using System;
using System.Globalization;
using System.Linq;
using WingsOn.Dal.Interfaces;
using WingsOn.Domain;

namespace WingsOn.Dal.Repositories
{
    /// <summary>
    /// The flight repository.
    /// </summary>
    public sealed class FlightRepository : RepositoryBase<Flight>
    {
        private readonly IRepository<Airport> _airportRepository;
        private readonly IRepository<Airline> _airlineRepository;
        private readonly CultureInfo _cultureInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightRepository"/> class.
        /// </summary>
        /// <param name="airportRepository">The airport repository.</param>
        /// <param name="airlineRepository">The airline repository.</param>
        public FlightRepository(
            IRepository<Airport> airportRepository,
            IRepository<Airline> airlineRepository)
        {
            _airportRepository = airportRepository;
            _airlineRepository = airlineRepository;

            // TODO: Put culture info in a config file.
            // TODO: Implement configuration provider.
            _cultureInfo = new CultureInfo("nl-NL");

            Repository.AddRange(new[]
            {
                new Flight
                {
                    Id = 30,
                    Number = "BB124",
                    DepartureAirport = _airportRepository.GetAll().Single(a => a.Code == "OQO"),
                    DepartureDate = DateTime.Parse("12/02/2012 16:50", _cultureInfo),
                    ArrivalAirport = _airportRepository.GetAll().Single(a => a.Code == "GJE"),
                    ArrivalDate = DateTime.Parse("13/02/2012 00:00", _cultureInfo),
                    Carrier = _airlineRepository.GetAll().Single(a => a.Code == "BB"),
                    Price = 196.1m
                },
                new Flight
                {
                    Id = 81,
                    Number = "PZ696",
                    DepartureAirport = _airportRepository.GetAll().Single(a => a.Code == "GJE"),
                    DepartureDate = DateTime.Parse("20/02/2000 17:50", _cultureInfo),
                    ArrivalAirport = _airportRepository.GetAll().Single(a => a.Code == "CZR"),
                    ArrivalDate = DateTime.Parse("20/02/2000 19:00", _cultureInfo),
                    Carrier = _airlineRepository.GetAll().Single(a => a.Code == "PZ"),
                    Price = 95.2m
                },
                new Flight
                {
                    Id = 41,
                    Number = "BB339",
                    ArrivalAirport = _airportRepository.GetAll().Single(a => a.Code == "ANH"),
                    ArrivalDate = DateTime.Parse("20/02/2000 17:50", _cultureInfo),
                    DepartureAirport = _airportRepository.GetAll().Single(a => a.Code == "GJE"),
                    DepartureDate = DateTime.Parse("20/02/2000 19:00", _cultureInfo),
                    Carrier = _airlineRepository.GetAll().Single(a => a.Code == "BB"),
                    Price = 57.6m
                },
                new Flight
                {
                    Id = 12,
                    Number = "BB910",
                    ArrivalAirport = _airportRepository.GetAll().Single(a => a.Code == "GJE"),
                    ArrivalDate = DateTime.Parse("17/07/2009 11:10", _cultureInfo),
                    DepartureAirport = _airportRepository.GetAll().Single(a => a.Code == "OQO"),
                    DepartureDate = DateTime.Parse("17/07/2009 13:45", _cultureInfo),
                    Carrier = _airlineRepository.GetAll().Single(a => a.Code == "BB"),
                    Price = 185m
                },
                new Flight
                {
                    Id = 31,
                    Number = "PZ956",
                    ArrivalAirport = _airportRepository.GetAll().Single(a => a.Code == "ANH"),
                    ArrivalDate = DateTime.Parse("28/05/2008 20:10", _cultureInfo),
                    DepartureAirport = _airportRepository.GetAll().Single(a => a.Code == "OQO"),
                    DepartureDate = DateTime.Parse("29/05/2008 13:30", _cultureInfo),
                    Carrier = _airlineRepository.GetAll().Single(a => a.Code == "PZ"),
                    Price = 1140.5m
                },
                new Flight
                {
                    Id = 21,
                    Number = "BB768",
                    ArrivalAirport = _airportRepository.GetAll().Single(a => a.Code == "ANH"),
                    ArrivalDate = DateTime.Parse("14/11/2006 21:00", _cultureInfo),
                    DepartureAirport = _airportRepository.GetAll().Single(a => a.Code == "OQO"),
                    DepartureDate = DateTime.Parse("15/11/2006 01:30", _cultureInfo),
                    Carrier = _airlineRepository.GetAll().Single(a => a.Code == "BB"),
                    Price = 416.17m
                }
            });
        }
    }
}