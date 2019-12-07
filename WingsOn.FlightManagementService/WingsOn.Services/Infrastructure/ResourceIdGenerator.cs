using System;
using System.Collections.Generic;
using System.Linq;
using WingsOn.Services.Infrastructure.Interfaces;
using WingsOn.Services.Models;

namespace WingsOn.Services.Infrastructure
{
    public sealed class ResourceIdGenerator : IResourceIdGenerator
    {
        // TODO: Put this value in a configuration file.
        // TODO: Use a configuration provider.
        // TODO (optional): Create custom config section.
        private const int IdIncrementingValue = 1;

        public int GenerateResourceId(IEnumerable<BaseModel> resources)
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