using Hangman.DomainCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman.DomainCore.Specifications
{
    public class WordWithSpecification : BaseSpecification<Word>
    {
        public WordWithSpecification()
            : base(o => string.IsNullOrEmpty(o.Name))
        {
           
        }
    }
}
