using System;
using WingsOn.Services.Interfaces;

namespace WingsOn.Services.Services
{
    /// <summary>
    /// The booking number generator.
    /// </summary>
    public class BookingNumberGenerator : IBookingNumberGenerator
    {
        // TODO: Put this value to a config file.
        // TODO: Implement configuration provider.
        // TODO (optional): Create custom config section.
        private const string BookingNumberPrefix = "WO";
        private const string BookingNumberTemplate = "{0}_{1}";

        /// <inheritdoc />
        public string GenerateBookingNumber()
        {
            return string.Format(BookingNumberTemplate, BookingNumberPrefix, Guid.NewGuid().ToString());
        }
    }
}