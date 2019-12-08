using System.Collections.Generic;
using System.Threading.Tasks;
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
        /// Returns all flights asynchronous.
        /// </summary>
        /// <returns>
        /// Returns a collection of instances of the <see cref="FlightModel"/> class.
        /// </returns>
        Task<IEnumerable<FlightModel>> GetAllFlightsAsync();

        /// <summary>
        /// Gets a flight by a flight number asynchronous.
        /// </summary>
        /// <param name="flightNumber">The number of a flight.</param>
        /// <returns>
        /// Returns an instance of the <see cref="FlightModel"/> class.
        /// </returns>
        Task<FlightModel> GetFlightAsync(string flightNumber);

        /// <summary>
        /// Gets a list of passengers for a particular flight asynchronous.
        /// </summary>
        /// <param name="flightNumber">The number of the flight.</param>
        /// <param name="gender">The gender.</param>
        /// <returns>
        /// Returns a collection of instances of the <see cref="PersonModel"/> class.
        /// </returns>
        Task<IEnumerable<PersonModel>> GetPassengersAsync(string flightNumber, GenderType gender);
    }
}