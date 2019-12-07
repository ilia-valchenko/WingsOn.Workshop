using System.ComponentModel.DataAnnotations;

namespace WingsOn.Api.ViewModels
{
    /// <summary>
    /// The base view model.
    /// </summary>
    public class BaseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel"/> class.
        /// </summary>
        protected BaseViewModel()
        {

        }

        /// <summary>
        /// The identifier.
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Id cannot be negative.")]
        public int Id { get; set; }
    }
}