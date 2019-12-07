using WingsOn.Services.Models;

namespace WingsOn.Services.Interfaces
{
    public interface IPersonValidationService
    {
        void ValidatePerson(PersonModel person);
    }
}