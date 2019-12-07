using System;
using System.ComponentModel.DataAnnotations;

namespace WingsOn.Api.ViewModels
{
    /// <summary>
    /// The flight view model.
    /// </summary>
    public sealed class FlightViewModel : BaseViewModel
    {
        /// <summary>
        /// The number of a flight.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Flight number is required.")]
        public string Number { get; set; }

        /// <summary>
        /// The carrier.
        /// </summary>
        public AirlineViewModel Carrier { get; set; }

        /// <summary>
        /// The departure airport.
        /// </summary>
        public AirportViewModel DepartureAirport { get; set; }

        /// <summary>
        /// The departure date.
        /// </summary>
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// The arrival airport.
        /// </summary>
        public AirportViewModel ArrivalAirport { get; set; }

        /// <summary>
        /// The arrival date.
        /// </summary>
        public DateTime ArrivalDate { get; set; }

        /// <summary>
        /// The price.
        /// </summary>
        public decimal Price { get; set; }
    }
}