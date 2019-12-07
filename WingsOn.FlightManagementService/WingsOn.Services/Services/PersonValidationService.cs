using System;
using WingsOn.Core.Exceptions;
using WingsOn.Services.Interfaces;
using WingsOn.Services.Models;

namespace WingsOn.Services.Services
{
    public sealed class PersonValidationService : IPersonValidationService
    {
        public void ValidatePerson(PersonModel person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            if (person.Id <= 0)
            {
                throw new InvalidResourceException("The person's id is less then zero or equal to zero.");
            }
        }
    }
}