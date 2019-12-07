using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WingsOn.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates web host builder.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>
        /// Returns an instance of the <see cref="IWebHostBuilder"/>.
        /// </returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
