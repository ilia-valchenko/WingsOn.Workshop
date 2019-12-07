using WingsOn.Domain;

namespace WingsOn.Dal.Repositories
{
    /// <summary>
    /// The airport repository.
    /// </summary>
    public sealed class AirportRepository : RepositoryBase<Airport>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirlineRepository"/> class.
        /// </summary>
        public AirportRepository()
        {
            Repository.AddRange(new[]
            {
                new Airport
                {
                    Id = 60,
                    Code = "OQO",
                    City = "Zwijnaarde",
                    Country = "Cuba"
                },
                new Airport
                {
                    Id = 98,
                    Code = "GJE",
                    City = "Ottignies",
                    Country = "Iran"
                },
                new Airport
                {
                    Id = 13,
                    Code = "CZR",
                    City = "Okigwe",
                    Country = "Mali"
                },
                new Airport
                {
                    Id = 80,
                    Code = "ANH",
                    City = "Chiniot",
                    Country = "Algeria"
                }
            });
        }
    }
}