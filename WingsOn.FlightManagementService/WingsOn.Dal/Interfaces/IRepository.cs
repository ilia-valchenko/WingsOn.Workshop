using System.Collections.Generic;
using WingsOn.Domain;

namespace WingsOn.Dal.Interfaces
{
    /// <summary>
    /// The repository interface.
    /// </summary>
    /// <typeparam name="T">The type of a resource.</typeparam>
    public interface IRepository<T> where T : DomainObject
    {
        /// <summary>
        /// Gets all resources.
        /// </summary>
        /// <returns>
        /// Returns a collection of all available resources.
        /// </returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets resource by id.
        /// </summary>
        /// <param name="id">The resource id.</param>
        /// <returns>
        /// Returns a resource with provided id.
        /// </returns>
        T Get(int id);

        /// <summary>
        /// Saves a resource.
        /// </summary>
        /// <param name="element">The resource.</param>
        void Save(T element);
    }
}