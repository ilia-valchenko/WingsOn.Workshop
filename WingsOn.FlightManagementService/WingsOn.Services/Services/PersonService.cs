using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

        // TODO: Implement cacheable providers that will wrap repositories.
        private readonly IRepository<Person> _personRepository;
        private readonly IResourceIdGenerator _resourceIdGenerator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonService"/> class.
        /// </summary>
        /// <param name="personRepository">The person repository.</param>
        /// <param name="resourceIdGenerator">The resource id generator.</param>
        /// <param name="mapper">The mapper.</param>
        public PersonService(
            IRepository<Person> personRepository,
            IResourceIdGenerator resourceIdGenerator,
            IMapper mapper)
        {
            _personRepository = personRepository;
            _resourceIdGenerator = resourceIdGenerator;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<PersonModel>> GetAllPersonsAsync()
        {
            var persons = await _personRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PersonModel>>(persons);
        }

        /// <inheritdoc />
        public async Task<PersonModel> CreatePersonAsync(PersonModel person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            if (DoesPersonExist(person.Id))
            {
                throw new ResourceAlreadyExistException("The provided person already exists.");
            }

            if (person.Id == 0)
            {
                person.Id = GenerateNextPersonId();
            }

            await _personRepository.SaveAsync(_mapper.Map<Person>(person));

            return person;
        }

        /// <inheritdoc />
        public async Task<PersonModel> GetPersonAsync(int id)
        {
            var person = await _personRepository.GetAsync(id);
            return _mapper.Map<PersonModel>(person);
        }

        /// <inheritdoc />
        public async Task UpdatePersonAsync(PersonModel person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            await _personRepository.SaveAsync(_mapper.Map<Person>(person));
        }

        /// <inheritdoc />
        public async Task RemovePersonAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("The provided identifier is less then zero or equals to zero.");
            }

            await _personRepository.RemoveAsync(id);
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
    }
}