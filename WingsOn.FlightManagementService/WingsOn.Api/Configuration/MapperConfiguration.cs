using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WingsOn.Api.ViewModels;
using WingsOn.Services.Models;

namespace WingsOn.Api.Configuration
{
    /// <summary>
    /// The mapper configuration.
    /// </summary>
    public static class MapperConfiguration
    {
        /// <summary>
        /// Registers mappings.
        /// </summary>
        /// <param name="collection">The service collection.</param>
        public static void RegisterMapper(IServiceCollection collection)
        {
            // TODO: Create AutoMapper wrapper in order to get rid of hard dependency.
            // Perhaps we will want to switch from AutoMapper to other mapper library.
            collection.AddSingleton(typeof(IMapper), CreateMapper());
        }

        /// <summary>
        /// Creates a mapper.
        /// </summary>
        /// <returns></returns>
        private static IMapper CreateMapper()
        {
            var mappings = new MapperConfigurationExpression();
            mappings.RegisterMappings();
            var config = new AutoMapper.MapperConfiguration(mappings);

            return config.CreateMapper();
        }

        private static IMapperConfigurationExpression RegisterMappings(this IMapperConfigurationExpression configuration)
        {
            Services.Configuration.MapperConfiguration.RegisterMappings(configuration);

            configuration.CreateMap<AirlineViewModel, AirlineModel>()
                .ReverseMap();

            configuration.CreateMap<AirportViewModel, AirportModel>()
                .ReverseMap();

            configuration.CreateMap<BaseViewModel, BaseModel>()
                .ReverseMap();

            configuration.CreateMap<BookingViewModel, BookingModel>()
                .ReverseMap();

            configuration.CreateMap<FlightViewModel, FlightModel>()
                .ReverseMap();

            configuration.CreateMap<PersonViewModel, PersonModel>()
                .ReverseMap();

            configuration.CreateMap<UpdatePersonViewModel, PersonModel>();

            return configuration;
        }
    }
}