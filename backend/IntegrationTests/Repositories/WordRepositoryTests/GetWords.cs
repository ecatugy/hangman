using Hangman.DomainCore.Entities;
using Hangman.WebApp;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace IntegrationTests.Repositories.WordRepositoryTests
{
    [TestClass]
    public class GetWords
    {
        private readonly CustomWebApplicationFactory _factory;

        public GetWords()
        {
            _factory = new CustomWebApplicationFactory();
        }

        [TestMethod]
        public async Task GetWordApi()
        {
            System.Diagnostics.Debugger.Launch();
            System.Diagnostics.Debugger.Break();
            var client = _factory.CreateClient();
          
            var response = await client.GetAsync("/api/word");

            response.EnsureSuccessStatusCode();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var words = JsonConvert.DeserializeObject<List<Word>>(jsonResult);
            Assert.AreEqual(words.Count,15);
        }
    }
}
