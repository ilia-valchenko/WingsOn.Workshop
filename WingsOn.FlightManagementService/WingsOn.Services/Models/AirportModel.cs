namespace WingsOn.Services.Models
{
    public sealed class AirportModel : BaseModel
    {
        public string Code { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
    }
}