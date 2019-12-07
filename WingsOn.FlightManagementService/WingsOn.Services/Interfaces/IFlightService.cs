using System.Collections.Generic;
using WingsOn.Core.Enums;
using WingsOn.Services.Models;

namespace WingsOn.Services.Interfaces
{
    /// <summary>
    /// The flight service interface.
    /// </summary>
    public interface IFlightService
    {
        /// <summary>
        /// Returns all flights.
        /// </summary>
        /// <returns>
        /// Returns a collection of instances of the <see cref="FlightModel"/> class.
        /// </returns>
        IEnumerable<FlightModel> GetAllFlights();

        /// <summary>
        /// Gets a flight by id.
        /// </summary>
        /// <param name="id">The flight's identifier.</param>
        /// <returns>
        /// Returns an instance of the <see cref="FlightModel"/> class.
        /// </returns>
        FlightModel GetFlight(int id);

        /// <summary>
        /// Gets a flight by a flight number.
        /// </summary>
        /// <param name="flightNumber">The number of a flight.</param>
        /// <returns>
        /// Returns an instance of the <see cref="FlightModel"/> class.
        /// </returns>
        FlightModel GetFlight(string flightNumber);

        /// <summary>
        /// Gets a list of passengers for a particular flight.
        /// </summary>
        /// <param name="flightNumber">The number of a flight.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>
        /// Returns a collection of instances of the <see cref="PersonModel"/> class.
        /// </returns>
        IEnumerable<PersonModel> GetPassengers(string flightNumber, GenderType? gender);
    }
}