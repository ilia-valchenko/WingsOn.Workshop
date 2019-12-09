using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using WingsOn.Api.Controllers;
using WingsOn.Api.Integration.Tests.Routes;

namespace WingsOn.Api.Integration.Tests
{
    /// <summary>
    /// The test class that contains integration tests for the <see cref="PersonsController"/> class.
    /// </summary>
    public class PersonsControllerIntegrationTests
    {
        private readonly HttpClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonsControllerIntegrationTests"/> class.
        /// </summary>
        public PersonsControllerIntegrationTests()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync(ApiRoutes.Persons.GetAllAsync.Replace("{personId}", "18"));

            // Assert
            Assert.IsNotNull(response);
        }
    }
}