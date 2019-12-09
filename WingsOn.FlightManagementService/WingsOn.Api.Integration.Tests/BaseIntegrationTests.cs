using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace WingsOn.Api.Integration.Tests
{
    /// <summary>
    /// The base class for all classes that contains integration tests.
    /// </summary>
    public class BaseIntegrationTests
    {
        /// <summary>
        /// The HTTP client.
        /// </summary>
        protected readonly HttpClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseIntegrationTests"/> class.
        /// </summary>
        public BaseIntegrationTests()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
        }
    }
}