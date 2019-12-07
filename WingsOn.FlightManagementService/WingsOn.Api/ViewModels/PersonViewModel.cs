using System;
using WingsOn.Core.Enums;

namespace WingsOn.Api.ViewModels
{
    /// <summary>
    /// The person view model.
    /// </summary>
    public sealed class PersonViewModel : BaseViewModel
    {
        /// <summary>
        /// The name of a person.
        /// </summary>
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
        public string Address { get; set; }

        /// <summary>
        /// The email.
        /// </summary>
        public string Email { get; set; }
    }
}