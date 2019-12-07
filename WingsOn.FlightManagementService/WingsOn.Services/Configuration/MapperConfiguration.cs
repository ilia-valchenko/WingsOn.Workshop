using AutoMapper;
using WingsOn.Domain;
using WingsOn.Services.Models;

namespace WingsOn.Services.Configuration
{
    /// <summary>
    /// The mapper configuration.
    /// </summary>
    public static class MapperConfiguration
    {
        /// <summary>
        /// Registers mappings.
        /// </summary>
        /// <param name="configuration">The configuration expression.</param>
        public static void RegisterMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<AirlineModel, Airline>()
                .ReverseMap();

            configuration.CreateMap<AirportModel, Airport>()
                .ReverseMap();

            configuration.CreateMap<BaseModel, DomainObject>()
                .ReverseMap();

            configuration.CreateMap<BookingModel, Booking>()
                .ReverseMap();

            configuration.CreateMap<FlightModel, Flight>()
                .ReverseMap();

            configuration.CreateMap<PersonModel, Person>()
                .ReverseMap();
        }
    }
}