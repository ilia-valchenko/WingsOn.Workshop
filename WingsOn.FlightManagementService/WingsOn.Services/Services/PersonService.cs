using System;
using System.Collections.Generic;
using System.Linq;
using WingsOn.Core.Exceptions;
using WingsOn.Dal.Interfaces;
using WingsOn.Domain;
using WingsOn.Services.Infrastructure.Interfaces;
using WingsOn.Services.Interfaces;
using WingsOn.Services.Models;

namespace WingsOn.Services.Services
{
    /// <summary>
    /// The person service.
    /// </summary>
    public sealed class PersonService : IPersonService
    {
        private static readonly object _lockObject = new object();

        // TODO: Use cacheable provider instead of repository.
        private readonly IRepository<Person> _personRepository;
        private readonly IResourceIdGenerator _resourceIdGenerator;
        private readonly IPersonValidationService _personValidationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonService"/> class.
        /// </summary>
        /// <param name="personRepository"></param>
        /// <param name="resourceIdGenerator"></param>
        /// <param name="personValidationService"></param>
        public PersonService(
            IRepository<Person> personRepository,
            IResourceIdGenerator resourceIdGenerator,
            IPersonValidationService personValidationService)
        {
            _personRepository = personRepository;
            _resourceIdGenerator = resourceIdGenerator;
            _personValidationService = personValidationService;
        }

        /// <inheritdoc />
        public IEnumerable<PersonModel> GetAllPersons()
        {
            var persons = _personRepository.GetAll();

            // TODO: Use AutoMapper.
            return persons.Select(MapToPersonModel);
        }

        /// <inheritdoc />
        public PersonModel CreatePerson(PersonModel person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            _personValidationService.ValidatePerson(person);

            if (DoesPersonExist(person.Id))
            {
                throw new ResourceAlreadyExistException("The provided person already exists.");
            }

            if (person.Id == 0)
            {
                person.Id = GenerateNextPersonId();
            }

            // TODO: Use AutoMapper.
            _personRepository.Save(MapToPerson(person));

            return person;
        }

        /// <inheritdoc />
        public PersonModel GetPerson(int id)
        {
            var person = _personRepository.Get(id);

            // TODO: Use AutoMapper.
            return MapToPersonModel(person);
        }

        /// <inheritdoc />
        public void UpdatePerson(PersonModel person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            _personValidationService.ValidatePerson(person);
            _personRepository.Save(MapToPerson(person));
        }

        /// <inheritdoc />
        public void RemovePerson(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("The provided identifier is less then zero or equals to zero.");
            }

            _personRepository.Remove(id);
        }

        /// <summary>
        /// Checks if a person exists.
        /// </summary>
        /// <param name="id">The person's identifier.</param>
        /// <returns>Returns true if a person exists.</returns>
        private bool DoesPersonExist(int id)
        {
            lock (_lockObject)
            {
                var persons = _personRepository.GetAll();

                return persons == null || !persons.Any()
                    ? false
                    : persons.Any(p => p.Id == id);
            }
        }

        /// <summary>
        /// Generates the next person's id.
        /// </summary>
        /// <returns>
        /// Returns the next person's id.
        /// </returns>
        private int GenerateNextPersonId()
        {
            lock (_lockObject)
            {
                var persons = _personRepository.GetAll();
                return _resourceIdGenerator.GenerateResourceId(persons);
            }
        }

        private Person MapToPerson(PersonModel personModel)
        {
            return new Person
            {
                Id = personModel.Id,
                Name = personModel.Name,
                Gender = personModel.Gender,
                Email = personModel.Email,
                Address = personModel.Address,
                DateBirth = personModel.DateBirth
            };
        }

        private PersonModel MapToPersonModel(Person person)
        {
            return new PersonModel
            {
                Id = person.Id,
                Name = person.Name,
                Gender = person.Gender,
                Email = person.Email,
                Address = person.Address,
                DateBirth = person.DateBirth
            };
        }
    }
}