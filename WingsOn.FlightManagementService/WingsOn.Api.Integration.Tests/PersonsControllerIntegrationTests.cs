using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using WingsOn.Api.Controllers;
using WingsOn.Api.Integration.Tests.Routes;
using WingsOn.Api.ViewModels;
using WingsOn.Core.Enums;

namespace WingsOn.Api.Integration.Tests
{
    /// <summary>
    /// The test class that contains integration tests for the <see cref="PersonsController"/> class.
    /// </summary>
    public class PersonsControllerIntegrationTests : BaseIntegrationTests
    {
        [Test]
        public async Task GetAsync_ReturnsAllPersons()
        {
            // Arrange
            for (int id = 1000; id < 1003; id++)
            {
                var person = CreatePerson(id);
                await _client.PostAsJsonAsync(ApiRoutes.Persons.PostAsync, person);
            }

            // Act
            var response = await _client.GetAsync(ApiRoutes.Persons.GetAllAsync);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsAsync<IEnumerable<PersonViewModel>>()).Should().NotBeEmpty();
        }

        [Test]
        public async Task GetAsync_ReturnsNotFoundIfPersonDoesNotExist()
        {
            // Arrange
            int id = 9999;

            // Act
            var response = await _client.GetAsync(ApiRoutes.Persons.GetAsync.Replace("{personId}", id.ToString()));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Test]
        public async Task GetAsync_ReturnsPersonWithProvidedId()
        {
            // Arrange
            int id = 2000;
            var person = CreatePerson(id);
            await _client.PostAsJsonAsync(ApiRoutes.Persons.PostAsync, person);

            // Act
            var response = await _client.GetAsync(ApiRoutes.Persons.GetAsync.Replace("{personId}", id.ToString()));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public async Task PostAsync_ReturnsCreatedPersonWithId()
        {
            // Arrange
            var person = CreatePerson();

            // Act
            var response = await _client.PostAsJsonAsync(ApiRoutes.Persons.PostAsync, person);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsAsync<PersonViewModel>()).Should().NotBeNull();
        }

        [Test]
        public async Task PutAsync_ReturnsNoContentResponse()
        {
            // Arrange
            var person = CreatePerson(3000);
            await _client.PostAsJsonAsync(ApiRoutes.Persons.PostAsync, person);
            person.Name = "Updated name";

            // Act
            var response = await _client.PutAsJsonAsync(
                ApiRoutes.Persons.PutAsync.Replace("{personId}", person.Id.ToString()),
                person);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Test]
        public async Task DeleteAsync_ReturnsNoContentResponse()
        {
            // Arrange
            var person = CreatePerson(5000);
            await _client.PostAsJsonAsync(ApiRoutes.Persons.PostAsync, person);

            // Act
            var response = await _client.DeleteAsync(ApiRoutes.Persons.DeleteAsync.Replace("{personId}", person.Id.ToString()));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        // TODO: Implement factory or builder that will be responsible for creating test persons.
        private PersonViewModel CreatePerson(int id = 0, GenderType gender = GenderType.Male)
        {
            return new PersonViewModel
            {
                Id = id,
                Email = $"fake{id}@test.com",
                Name = $"Fake name {id}",
                Address = $"Fake address {id}",
                Gender = gender,
                DateBirth = DateTime.UtcNow
            };
        }
    }
}