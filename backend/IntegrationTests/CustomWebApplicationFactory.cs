
using Hangman.DomainCore.Interfaces;
using Hangman.Infrastructure.Data;
using Hangman.Infrastructure.Data.Config;
using Hangman.WebApp;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;


namespace IntegrationTests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                // Add a database context (ApplicationDbContext) using an in-memory 
                // database for testing.
                services.AddDbContext<WordDBContext>(options =>
                {
                    options.UseInMemoryDatabase("WordDB");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database
                // context (WordDBContext).
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;

                    //Get the instance of BoardGamesDBContext in our services layer
                    var servicesProv = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<WordDBContext>();

                    // Ensure the database is created.
                    db.Database.EnsureCreated();
                    // Seed the database with test data.
                    DataGenerator.Seed(db);
                }
            });
        }
    }

}
