namespace WingsOn.Api.ViewModels
{
    /// <summary>
    /// The airline view model.
    /// </summary>
    public sealed class AirlineViewModel : BaseViewModel
    {
        /// <summary>
        /// The airline's code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The name of an airline.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The address.
        /// </summary>
        public string Address { get; set; }
    }
}