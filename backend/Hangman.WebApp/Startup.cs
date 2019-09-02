using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangman.DomainCore.Interfaces;
using Hangman.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hangman.WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                    .AddJsonFormatters();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowCors", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });


            //Database populated by xml data
            services.AddDbContext<WordDBContext>(options => options.UseInMemoryDatabase(databaseName: "WordDB"));
            services.AddScoped<IWordRepository, WordRepository>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowCors");
            app.UseMvc();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
        }
    }
}
