using Microsoft.Extensions.DependencyInjection;

namespace WingsOn.Api.Configuration
{
    /// <summary>
    /// Dependency configurator.
    /// </summary>
    public static class DIConfiguration
    {
        /// <summary>
        /// Registers dependencies.
        /// </summary>
        /// <param name="collection">The service collection.</param>
        /// <returns>
        /// Returns the service collection that contains registered dependencies.
        /// </returns>
        public static IServiceCollection RegisterDependencies(this IServiceCollection collection)
        {
            Services.Configuration.DIConfiguration.RegisterDependencies(collection);

            return collection;
        }
    }
}