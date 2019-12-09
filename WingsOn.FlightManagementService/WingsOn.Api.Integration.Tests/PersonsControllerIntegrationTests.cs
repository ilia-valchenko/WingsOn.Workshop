using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using NUnit.Framework;
using WingsOn.Api.Controllers;
using WingsOn.Api.Integration.Tests.Routes;
using WingsOn.Services.Interfaces;

namespace WingsOn.Api.Integration.Tests
{
    /// <summary>
    /// The test class that contains integration tests for the <see cref="PersonsController"/> class.
    /// </summary>
    public class PersonsControllerIntegrationTests
    {
        private readonly HttpClient _client;

        private Mock<IPersonService> _personServiceMock;
        private Mock<IMapper> _mapperMock;

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
            _personServiceMock = new Mock<IPersonService>();
            _mapperMock = new Mock<IMapper>();
        }

        [Test]
        public async Task GetAsync_ReturnsAllPersons()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync(ApiRoutes.Persons.GetAllAsync);

            // Assert
            // TODO: Validate the response.
        }
    }
}