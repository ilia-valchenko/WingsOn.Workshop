using System;
using System.ComponentModel.DataAnnotations;
using WingsOn.Core.Enums;

namespace WingsOn.Api.ViewModels
{
    /// <summary>
    /// The view model that is used for updating the person.
    /// </summary>
    /// <remarks>
    /// This view model does not contain Id property.
    /// </remarks>
    public sealed class UpdatePersonViewModel
    {
        /// <summary>
        /// The name of a person.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        /// <summary>
        /// The date of birth.
        /// </summary>
        public DateTime DateBirth { get; set; }

        /// <summary>
        /// The person's gender.
        /// </summary>
        public GenderType Gender { get; set; }

        /// <summary>
        /// The address.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        /// <summary>
        /// The email.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
    }
}