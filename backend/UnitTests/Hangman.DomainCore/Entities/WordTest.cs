using Hangman.DomainCore.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Hangman.DomainCore.Entities
{
    [TestClass]
    public class WordTest
    {
        /// <summary>
        /// Testa método DecryptString da classe CryptoProvider
        /// </summary>
        [TestMethod]
        public void IsNameIDNotNull()
        {
            var value = new Word { Id = 1, Name = "Teste value" };
            Assert.IsNotNull(value.Id);
            Assert.IsNotNull(value.Name);
        }
    }
}
