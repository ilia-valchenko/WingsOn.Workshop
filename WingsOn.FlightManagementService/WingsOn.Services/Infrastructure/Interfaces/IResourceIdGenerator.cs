using System.Collections.Generic;
using WingsOn.Domain;

namespace WingsOn.Services.Infrastructure.Interfaces
{
    /// <summary>
    /// The resource generator interface.
    /// </summary>
    public interface IResourceIdGenerator
    {
        /// <summary>
        /// Generates the next resource's id.
        /// </summary>
        /// <param name="resources">The collection of available resources.</param>
        /// <returns>
        /// Returns the next resource's id.
        /// </returns>
        int GenerateResourceId(IEnumerable<DomainObject> resources);
    }
}