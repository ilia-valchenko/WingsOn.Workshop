using WingsOn.Services.Models;

namespace WingsOn.Services.Interfaces
{
    /// <summary>
    /// The person validation service.
    /// </summary>
    public interface IPersonValidationService
    {
        /// <summary>
        /// Validates a person.
        /// </summary>
        /// <param name="person">The person.</param>
        void ValidatePerson(PersonModel person);
    }
}