using System.Collections.Generic;
using System.Threading.Tasks;
using WingsOn.Services.Models;

namespace WingsOn.Services.Interfaces
{
    /// <summary>
    /// The person service interface.
    /// </summary>
    public interface IPersonService
    {
        /// <summary>
        /// Gets all persons asynchronous.
        /// </summary>
        /// <returns>
        /// Returns a collection of <see cref="PersonModel"/> class.
        /// </returns>
        Task<IEnumerable<PersonModel>> GetAllPersonsAsync();

        /// <summary>
        /// Creates a new person asynchronous.
        /// </summary>
        /// <param name="person">The person model.</param>
        /// <returns>
        /// Returns an instance of the <see cref="PersonModel"/> class.
        /// </returns>
        Task<PersonModel> CreatePersonAsync(PersonModel person);

        /// <summary>
        /// Gets person by id asynchronous.
        /// </summary>
        /// <param name="id">The person's identifier.</param>
        /// <returns>
        /// Returns an instance of the <see cref="PersonModel"/> class.
        /// </returns>
        Task<PersonModel> GetPersonAsync(int id);

        /// <summary>
        /// Updates a person asynchronous.
        /// </summary>
        /// <param name="person">The updated person model.</param>
        Task UpdatePersonAsync(PersonModel person);

        /// <summary>
        /// Removes a person by provided id asynchronous.
        /// </summary>
        /// <param name="id">The person's identifier.</param>
        Task RemovePersonAsync(int id);
    }
}