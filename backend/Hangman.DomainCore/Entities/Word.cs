using Hangman.DomainCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman.DomainCore.Entities
{
    public class Word : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
    }
}
