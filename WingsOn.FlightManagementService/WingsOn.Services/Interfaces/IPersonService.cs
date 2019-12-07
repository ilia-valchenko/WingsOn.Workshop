using System.Collections.Generic;
using WingsOn.Services.Models;

namespace WingsOn.Services.Interfaces
{
    /// <summary>
    /// The person service interface.
    /// </summary>
    public interface IPersonService
    {
        /// <summary>
        /// Gets all persons.
        /// </summary>
        /// <returns>
        /// Returns a collection of <see cref="PersonModel"/> class.
        /// </returns>
        IEnumerable<PersonModel> GetAllPersons();

        /// <summary>
        /// Creates a new person.
        /// </summary>
        /// <param name="person">The person model.</param>
        /// <returns>
        /// Returns an instance of the <see cref="PersonModel"/> class.
        /// </returns>
        PersonModel CreatePerson(PersonModel person);

        /// <summary>
        /// Gets person by id.
        /// </summary>
        /// <param name="id">The person's identifier.</param>
        /// <returns>
        /// Returns an instance of the <see cref="PersonModel"/> class.
        /// </returns>
        PersonModel GetPerson(int id);

        /// <summary>
        /// Updates a person.
        /// </summary>
        /// <param name="person">The updated person model.</param>
        void UpdatePerson(PersonModel person);

        /// <summary>
        /// Removes a person by provided id.
        /// </summary>
        /// <param name="id">The person's identifier.</param>
        void RemovePerson(int id);
    }
}