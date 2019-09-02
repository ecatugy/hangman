using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman.DomainCore.Exceptions
{
    public class WordNotFoundException : Exception
    {
        public WordNotFoundException(int id) : base($"No word found with id {id}")
        {
        }

        protected WordNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }

        public WordNotFoundException(string message) : base(message)
        {
        }

        public WordNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
