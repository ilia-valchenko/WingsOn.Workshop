using System;

namespace WingsOn.Services.Models
{
    public sealed class PersonModel : BaseModel
    {
        public string Name { get; set; }

        public DateTime DateBirth { get; set; }

        public GenderType Gender { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
    }
}