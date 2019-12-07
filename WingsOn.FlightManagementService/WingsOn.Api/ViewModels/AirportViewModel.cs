using System.ComponentModel.DataAnnotations;

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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Code is required.")]
        public string Code { get; set; }

        /// <summary>
        /// The country where an airport is located.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country is required.")]
        public string Country { get; set; }

        /// <summary>
        /// The city where an airport is located.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "City is required.")]
        public string City { get; set; }
    }
}