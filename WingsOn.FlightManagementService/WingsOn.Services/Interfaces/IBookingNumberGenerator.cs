namespace WingsOn.Services.Interfaces
{
    /// <summary>
    /// The booking number generator interface.
    /// </summary>
    public interface IBookingNumberGenerator
    {
        /// <summary>
        /// Generates the number for a new booking.
        /// </summary>
        /// <returns></returns>
        string GenerateBookingNumber();
    }
}