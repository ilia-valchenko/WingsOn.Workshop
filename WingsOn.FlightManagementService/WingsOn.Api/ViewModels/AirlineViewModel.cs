using System.ComponentModel.DataAnnotations;

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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Code is required.")]
        public string Code { get; set; }

        /// <summary>
        /// The name of an airline.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        /// <summary>
        /// The address.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address is required.")]
        public string Address { get; set; }
    }
}