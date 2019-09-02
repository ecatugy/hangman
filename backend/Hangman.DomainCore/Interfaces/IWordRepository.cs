using Hangman.DomainCore.Entities;
using Hangman.DomainCore.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hangman.DomainCore.Interfaces
{
    public interface IWordRepository
    {
        Task<IReadOnlyList<Word>> ListAsync();
        Task ListAsync(WordWithSpecification wordWithSpecification);
    }
}
