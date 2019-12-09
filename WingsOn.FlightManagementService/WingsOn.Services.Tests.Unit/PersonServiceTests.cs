using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using WingsOn.Core.Enums;
using WingsOn.Core.Exceptions;
using WingsOn.Dal.Interfaces;
using WingsOn.Domain;
using WingsOn.Services.Infrastructure.Interfaces;
using WingsOn.Services.Models;
using WingsOn.Services.Services;

namespace WingsOn.Services.Tests.Unit
{
    public class PersonServiceTests
    {
        private Mock<IRepository<Person>> _personRepositoryMock;
        private Mock<IResourceIdGenerator> _resourceIdGeneratorMock;
        private Mock<IMapper> _mapperMock;
        private PersonService _personService;
        private IEnumerable<Person> _persons;

        [SetUp]
        public void Setup()
        {
            _personRepositoryMock = new Mock<IRepository<Person>>();
            _resourceIdGeneratorMock = new Mock<IResourceIdGenerator>();
            _mapperMock = new Mock<IMapper>();
            _persons = CreatePersons();

            _personService = new PersonService(
                _personRepositoryMock.Object,
                _resourceIdGeneratorMock.Object,
                _mapperMock.Object);
        }

        [Test]
        public async Task GetAllPersonsAsync_VerifyThatRepositoryMethodIsCalled()
        {
            // Arrange
            _personRepositoryMock.Setup(r => r.GetAllAsync())
                .ReturnsAsync(_persons)
                .Verifiable();

            // Act
            await _personService.GetAllPersonsAsync();

            // Assert
            _personRepositoryMock.VerifyAll();
        }

        [Test]
        public async Task GetAllPersonsAsync_VerifyThatResultIsValid()
        {
            // Arrange
            _personRepositoryMock.Setup(r => r.GetAllAsync())
                .ReturnsAsync(_persons)
                .Verifiable();

            SetupMapToPersonModelMethod(_persons);
            var expectedResult = _persons.Select(MapToPersonModel);

            // Act
            var result = await _personService.GetAllPersonsAsync();

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void CreatePersonAsync_CheckIfArgumentExceptionIsThrown()
        {
            // Arrange
            PersonModel person = null;

            // Act + Assert
            _personService.Invoking(y => y.CreatePersonAsync(person))
                .Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void CreatePersonAsync_CheckIfResourceAlreadyExistExceptionIsThrown()
        {
            // Arrange
            _personRepositoryMock.Setup(m => m.GetAll())
                .Returns(_persons);

            var person = MapToPersonModel(_persons.FirstOrDefault());

            // Act + Assert
            _personService.Invoking(y => y.CreatePersonAsync(person))
                .Should().Throw<ResourceAlreadyExistException>();
        }

        [Test]
        public async Task CreatePersonAsync_VerifyThatRepositorySaveAsyncMethodIsCalled()
        {
            // Arrange
            var person = new Person
            {
                Email = "fake@test.com",
                Address = "Fake address",
                Gender = GenderType.Male,
                Name = "Fake name"
            };

            var personModel = MapToPersonModel(person);

            _personRepositoryMock.Setup(r => r.SaveAsync(It.Is<Person>(p => p.Name == person.Name)))
                .Returns(Task.FromResult(person))
                .Verifiable();

            SetupMapToPersonMethod(personModel);

            // Act
            await _personService.CreatePersonAsync(personModel);

            // Assert
            _personRepositoryMock.VerifyAll();
        }

        [Test]
        public async Task CreatePersonAsync_VerifyThatCreatedPersonIsValid()
        {
            // Arrange
            var person = new Person
            {
                Id = 0,
                Email = "fake@test.com",
                Address = "Fake address",
                Gender = GenderType.Male,
                Name = "Fake name"
            };

            var personModel = MapToPersonModel(person);
            var expectedResult = MapToPersonModel(person);
            expectedResult.Id = _persons.Select(p => p.Id).Max() + 1;

            _personRepositoryMock.Setup(m => m.GetAll())
                .Returns(_persons);

            _personRepositoryMock.Setup(r => r.SaveAsync(It.Is<Person>(p => p.Name == person.Name)))
                .Returns(Task.FromResult(person))
                .Verifiable();

            _resourceIdGeneratorMock.Setup(g => g.GenerateResourceId(It.IsAny<IEnumerable<Person>>()))
                .Returns(expectedResult.Id);

            SetupMapToPersonMethod(personModel);

            // Act
            var result = await _personService.CreatePersonAsync(personModel);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public async Task GetPersonAsync_CheckIfPersonIsValid()
        {
            // Arrange
            var person = _persons.First();

            _personRepositoryMock.Setup(r => r.GetAsync(person.Id))
                .ReturnsAsync(person);

            SetupMapToPersonModelMethod(person);

            // Act
            var result = await _personService.GetPersonAsync(person.Id);

            // Assert
            result.Should().BeEquivalentTo(person);
        }

        [Test]
        public void UpdatePersonAsync_CheckIfArgumentNullExceptionIsThrown()
        {
            // Arrange
            PersonModel person = null;

            // Act + Assert
            _personService.Invoking(y => y.UpdatePersonAsync(person))
                .Should().Throw<ArgumentNullException>();
        }

        [Test]
        public async Task UpdatePersonAsync_VerifyThatPersonWasSuccessfullyUpdated()
        {
            // Arrange
            var person = new Person
            {
                Id = 1,
                Name = "Fake name"
            };

            var personModel = MapToPersonModel(person);

            _personRepositoryMock.Setup(r => r.SaveAsync(It.IsAny<Person>()))
                .Returns(Task.FromResult(person))
                .Verifiable();

            SetupMapToPersonMethod(personModel);

            // Act
            await _personService.UpdatePersonAsync(personModel);

            // Assert
            _personRepositoryMock.VerifyAll();
        }

        [Test]
        public void RemovePersonAsync_CheckIfArgumentExceptionIsThrown()
        {
            // Arrange
            int id = -1;

            // Act + Assert
            _personService.Invoking(y => y.RemovePersonAsync(id))
                .Should().Throw<ArgumentException>();
        }

        [Test]
        public async Task RemovePersonAsync_VerifyThatPersonIsRemoved()
        {
            // Arrange
            int id = 1;

            _personRepositoryMock.Setup(r => r.RemoveAsync(id))
                .Verifiable();

            // Act
            await _personService.RemovePersonAsync(id);

            // Assert
            _personRepositoryMock.VerifyAll();
        }

        // TODO: Implement factory or builder for creating persons.
        private IEnumerable<Person> CreatePersons()
        {
            return new[]
            {
                new Person
                {
                    Id = 1,
                    Name = "Fake person name 1",
                    Email = "fake1@test.com",
                    Gender = GenderType.Male
                },
                new Person
                {
                    Id = 2,
                    Name = "Fake person name 2",
                    Email = "fake2@test.com",
                    Gender = GenderType.Female
                },
                new Person
                {
                    Id = 3,
                    Name = "Fake person name 3",
                    Email = "fake3@test.com",
                    Gender = GenderType.Male
                },
                new Person
                {
                    Id = 4,
                    Name = "Fake person name 4",
                    Email = "fake4@test.com",
                    Gender = GenderType.Female
                }
            };
        }

        private void SetupMapToPersonModelMethod(IEnumerable<Person> persons)
        {
            _mapperMock.Setup(m => m.Map<IEnumerable<PersonModel>>(persons))
                .Returns(persons.Select(MapToPersonModel))
                .Verifiable();
        }

        private void SetupMapToPersonModelMethod(Person person)
        {
            _mapperMock.Setup(m => m.Map<PersonModel>(person))
                .Returns(MapToPersonModel(person))
                .Verifiable();
        }

        private void SetupMapToPersonMethod(PersonModel person)
        {
            _mapperMock.Setup(m => m.Map<Person>(person))
                .Returns(MapToPerson(person))
                .Verifiable();
        }

        private PersonModel MapToPersonModel(Person person)
        {
            return new PersonModel
            {
                Id = person.Id,
                Name = person.Name,
                Email = person.Email,
                Gender = person.Gender,
                Address = person.Address,
                DateBirth = person.DateBirth
            };
        }

        private Person MapToPerson(PersonModel person)
        {
            return new Person
            {
                Id = person.Id,
                Name = person.Name,
                Email = person.Email,
                Gender = person.Gender,
                Address = person.Address,
                DateBirth = person.DateBirth
            };
        }
    }
}