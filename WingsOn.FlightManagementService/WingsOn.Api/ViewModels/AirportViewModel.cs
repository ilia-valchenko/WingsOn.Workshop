namespace WingsOn.Api.ViewModels
{
    /// <summary>
    /// The airport view model.
    /// </summary>
    public sealed class AirportViewModel : BaseViewModel
    {
        /// <summary>
        /// The code of an airport.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The country where an airport is located.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// The city where an airport is located.
        /// </summary>
        public string City { get; set; }
    }
}