using Hangman.DomainCore.Entities;
using Hangman.DomainCore.Interfaces;
using Hangman.DomainCore.Specifications;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Hangman.Infrastructure.Data
{
    public class WordRepository : EfRepository<Word>, IWordRepository
    {

        public WordRepository(WordDBContext dbContext) : base(dbContext)
        {
        }

        public Task ListAsync(WordWithSpecification wordWithSpecification)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Word>> ListAsync()
        {
            return await _dbContext.Words.ToListAsync();
        }
    }
}
