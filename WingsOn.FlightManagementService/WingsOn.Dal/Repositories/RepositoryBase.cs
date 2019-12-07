using System;
using System.Collections.Generic;
using System.Linq;
using WingsOn.Core.Exceptions;
using WingsOn.Dal.Interfaces;
using WingsOn.Domain;

namespace WingsOn.Dal.Repositories
{
    /// <summary>
    /// The base repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepositoryBase<T> : IRepository<T> where T : DomainObject
    {
        /// <summary>
        /// The collection of resources.
        /// </summary>
        protected List<T> Repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T}"/> class.
        /// </summary>
        protected RepositoryBase()
        {
            Repository = new List<T>();
        }

        /// <inheritdoc />
        public IEnumerable<T> GetAll()
        {
            return Repository;
        }

        /// <inheritdoc />
        public T Get(int id)
        {
            return GetAll().SingleOrDefault(a => a.Id == id);
        }

        /// <inheritdoc />
        public T Find(Predicate<T> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return Repository.Find(predicate);
        }

        /// <inheritdoc />
        public IEnumerable<T> FindAll(Predicate<T> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return Repository.FindAll(predicate);
        }

        /// <inheritdoc />
        public void Save(T element)
        {
            if (element == null)
            {
                return;
            }

            T existing = Get(element.Id);

            if (existing != null)
            {
                Repository.Remove(existing);
            }

            Repository.Add(element);
        }

        /// <inheritdoc />
        public void Remove(int id)
        {
            T item = Get(id);

            if (item == null)
            {
                throw new ResourceNotFoundException("Resource with provided id does not exist.");
            }

            Repository.Remove(item);
        }
    }
}