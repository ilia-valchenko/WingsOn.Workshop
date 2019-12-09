namespace WingsOn.Api.Integration.Tests.Routes
{
    public static class ApiRoutes
    {
        private const string Base = "http://localhost:63533/api/v1";

        public static class Persons
        {
            public const string GetAllAsync = Base + "/persons";

            public const string GetAsync = Base + "/persons/{personId}";

            public const string PostAsync = Base + "/persons";

            public const string PutAsync = Base + "/persons";
        }
    }
}