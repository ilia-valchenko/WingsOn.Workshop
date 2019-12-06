using System.Collections.Generic;
using WingsOn.Services.Models;

namespace WingsOn.Services.Interfaces
{
    public interface IPersonService
    {
        IEnumerable<PersonModel> GetAllPersons();

        PersonModel CreatePerson(PersonModel person);

        PersonModel GetPerson(int id);

        void UpdatePerson(PersonModel person);

        void RemovePerson(int id);
    }
}