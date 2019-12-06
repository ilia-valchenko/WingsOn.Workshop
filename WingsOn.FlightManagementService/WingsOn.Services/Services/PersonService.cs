using System;
using System.Collections.Generic;
using WingsOn.Services.Interfaces;
using WingsOn.Services.Models;

namespace WingsOn.Services.Services
{
    public sealed class PersonService : IPersonService
    {
        public IEnumerable<PersonModel> GetAllPersons()
        {
            throw new NotImplementedException();
        }

        public PersonModel CreatePerson(PersonModel person)
        {
            throw new NotImplementedException();
        }

        public PersonModel GetPerson(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePerson(PersonModel person)
        {
            throw new NotImplementedException();
        }

        public void RemovePerson(int id)
        {
            throw new NotImplementedException();
        }
    }
}