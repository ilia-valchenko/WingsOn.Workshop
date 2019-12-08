using System.Threading.Tasks;
using WingsOn.Services.Models;

namespace WingsOn.Services.Interfaces
{
    /// <summary>
    /// The booking service interface.
    /// </summary>
    public interface IBookingService
    {
        /// <summary>
        /// Creates a new booking of an existing flight for a new passenger asynchronous.
        /// </summary>
        /// <param name="flightNumber">The number of the flight.</param>
        /// <param name="passenger">The passenger.</param>
        /// <returns>
        /// Returns an instance of the <see cref="BookingModel"/> class.
        /// </returns>
        Task<BookingModel> CreateBookingAsync(string flightNumber, PersonModel passenger);
    }
}