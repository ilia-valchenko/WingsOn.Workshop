using System;
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
        /// Finds resource by predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// Returns a single resource that satisfies predicate's condition.
        /// </returns>
        T Find(Predicate<T> predicate);

        /// <summary>
        /// Finds all resources that satisfy predicate's condition.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// Returns a collection of resources that satisfies predicates's condition.
        /// </returns>
        IEnumerable<T> FindAll(Predicate<T> predicate);

        /// <summary>
        /// Saves a resource.
        /// </summary>
        /// <param name="element">The resource.</param>
        void Save(T element);

        /// <summary>
        /// Removes a resources by using provided id.
        /// </summary>
        /// <param name="id">The identifier of a resource that should be removed.</param>
        void Remove(int id);
    }
}