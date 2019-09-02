using Hangman.DomainCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman.Infrastructure.Data
{

    public class WordDBContext : DbContext
    {
        public WordDBContext(DbContextOptions<WordDBContext> options)
            : base(options)
        {
        }

        public DbSet<Word> Words { get; set; }
    }
}
