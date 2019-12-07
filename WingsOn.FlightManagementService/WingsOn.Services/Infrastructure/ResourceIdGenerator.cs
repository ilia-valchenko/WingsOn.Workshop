using System;
using System.Collections.Generic;
using System.Linq;
using WingsOn.Domain;
using WingsOn.Services.Infrastructure.Interfaces;

namespace WingsOn.Services.Infrastructure
{
    /// <summary>
    /// The resource identifier generator.
    /// </summary>
    public sealed class ResourceIdGenerator : IResourceIdGenerator
    {
        // TODO: Put this value in a configuration file.
        // TODO: Use a configuration provider.
        // TODO (optional): Create custom config section.
        private const int IdIncrementingValue = 1;

        /// <inheritdoc />
        public int GenerateResourceId(IEnumerable<DomainObject> resources)
        {
            if (resources == null)
            {
                throw new ArgumentNullException(nameof(resources));
            }

            return !resources.Any()
                ? IdIncrementingValue
                : resources.Select(p => p.Id).Max() + IdIncrementingValue;
        }
    }
}