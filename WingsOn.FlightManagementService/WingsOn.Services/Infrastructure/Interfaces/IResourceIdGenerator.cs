using System.Collections.Generic;
using WingsOn.Services.Models;

namespace WingsOn.Services.Infrastructure.Interfaces
{
    public interface IResourceIdGenerator
    {
        int GenerateResourceId(IEnumerable<BaseModel> resources);
    }
}