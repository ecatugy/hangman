using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangman.DomainCore.Interfaces;
using Hangman.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hangman.WebApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly IWordRepository _wordRepository;

        public WordController(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }


        [HttpGet()]
        public async Task<IActionResult> GetWords()
        {
            var orders = await _wordRepository.ListAsync();

            var viewModel = orders.Select(o => new WordViewModel
            {
                Name = o.Name
            });

            return Ok(viewModel);
        }
    }
}