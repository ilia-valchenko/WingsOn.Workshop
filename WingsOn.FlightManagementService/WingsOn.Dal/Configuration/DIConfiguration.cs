using Microsoft.Extensions.DependencyInjection;
using WingsOn.Dal.Interfaces;
using WingsOn.Dal.Repositories;
using WingsOn.Domain;

namespace WingsOn.Dal.Configuration
{
    /// <summary>
    /// Dependency configurator.
    /// </summary>
    public static class DIConfiguration
    {
        /// <summary>
        /// Registers dependencies.
        /// </summary>
        /// <param name="collection">The service collection.</param>
        /// <returns>
        /// Returns the service collection that contains registered dependencies.
        /// </returns>
        public static void RegisterDependencies(IServiceCollection collection)
        {
            // TODO: Implement production ready DAL (e.g. real database + ORM framework).
            // In this dummy implementation I want to keep a state of a database.
            // That is why I changed Transient to Singleton lifetime.
            // I want to track the result of my CRUD operations.
            collection.AddSingleton<IRepository<Person>, PersonRepository>();
            collection.AddSingleton<IRepository<Airport>, AirportRepository>();
            collection.AddSingleton<IRepository<Airline>, AirlineRepository>();
            collection.AddSingleton<IRepository<Flight>, FlightRepository>();
            collection.AddSingleton<IRepository<Booking>, BookingRepository>();
        }
    }
}