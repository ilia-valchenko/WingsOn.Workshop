using System;
using System.Collections.Generic;

namespace WingsOn.Services.Models
{
    public sealed class BookingModel : BaseModel
    {
        public string Number { get; set; }

        public FlightModel Flight { get; set; }

        public PersonModel Customer { get; set; }

        public IEnumerable<PersonModel> Passengers { get; set; }

        public DateTime DateBooking { get; set; }
    }
}