using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.Run(() => Repository);
        }

        /// <inheritdoc />
        public async Task<T> GetAsync(int id)
        {
            var resources = await GetAllAsync();
            return resources.SingleOrDefault(a => a.Id == id);
        }

        /// <inheritdoc />
        public async Task<T> FindAsync(Predicate<T> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return await Task.Run(() => Repository.Find(predicate));
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> FindAllAsync(Predicate<T> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return await Task.Run(() => Repository.FindAll(predicate));
        }

        /// <inheritdoc />
        public async Task SaveAsync(T element)
        {
            if (element == null)
            {
                return;
            }

            T existing = await GetAsync(element.Id);

            if (existing != null)
            {
                Repository.Remove(existing);
            }

            Repository.Add(element);
        }

        /// <inheritdoc />
        public async Task RemoveAsync(int id)
        {
            T item = await GetAsync(id);

            if (item == null)
            {
                throw new ResourceNotFoundException("Resource with provided id does not exist.");
            }

            Repository.Remove(item);
        }
    }
}