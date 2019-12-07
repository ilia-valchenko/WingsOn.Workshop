using System;
using System.Collections.Generic;

namespace WingsOn.Api.ViewModels
{
    /// <summary>
    /// The booking view model.
    /// </summary>
    public sealed class BookingViewModel : BaseViewModel
    {
        /// <summary>
        /// The number of a booking.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// The flight.
        /// </summary>
        public FlightViewModel Flight { get; set; }

        /// <summary>
        /// The customer.
        /// </summary>
        public PersonViewModel Customer { get; set; }

        /// <summary>
        /// The list of passengers.
        /// </summary>
        public IEnumerable<PersonViewModel> Passengers { get; set; }

        /// <summary>
        /// The date of a booking.
        /// </summary>
        public DateTime DateBooking { get; set; }
    }
}