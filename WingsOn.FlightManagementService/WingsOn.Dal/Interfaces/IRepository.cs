using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        /// Gets all resources asynchronous.
        /// </summary>
        /// <returns>
        /// Returns a collection of all available resources.
        /// </returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Gets resource by id asynchronous.
        /// </summary>
        /// <param name="id">The resource id.</param>
        /// <returns>
        /// Returns a resource with provided id.
        /// </returns>
        Task<T> GetAsync(int id);

        /// <summary>
        /// Finds resource by predicate asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// Returns a single resource that satisfies predicate's condition.
        /// </returns>
        Task<T> FindAsync(Predicate<T> predicate);

        /// <summary>
        /// Finds all resources that satisfy predicate's condition asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// Returns a collection of resources that satisfies predicates's condition.
        /// </returns>
        Task<IEnumerable<T>> FindAllAsync(Predicate<T> predicate);

        /// <summary>
        /// Saves a resource asynchronous.
        /// </summary>
        /// <param name="element">The resource.</param>
        Task SaveAsync(T element);

        /// <summary>
        /// Removes a resources by using provided id asynchronous.
        /// </summary>
        /// <param name="id">The identifier of a resource that should be removed.</param>
        Task RemoveAsync(int id);
    }
}