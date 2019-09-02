using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Hangman.Infrastructure.Data;
using Hangman.Infrastructure.Data.Config;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Hangman.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //Get the IWebHost which will host this application.
            var host = CreateWebHostBuilder(args).Build();

            //Find the service layer within our scope.
            using (var scope = host.Services.CreateScope())
            {
                //Get the instance of BoardGamesDBContext in our services layer
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<WordDBContext>();

                //Call the DataGenerator to create sample data (xml)
                DataGenerator.Initialize(services);
            }

            //Continue to run the application
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
