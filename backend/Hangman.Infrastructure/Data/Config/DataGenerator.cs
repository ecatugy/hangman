using Hangman.DomainCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Hangman.Infrastructure.Data.Config
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WordDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<WordDBContext>>()))

            {
                Seed(context);
            }

        }

        public static void Seed(WordDBContext context)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceStream = assembly.GetManifestResourceStream("Hangman.Infrastructure.Data.Word.xml");
            var xml = XDocument.Load(resourceStream);

            foreach (var element in xml.Descendants("word_list"))
            {
                var i = 1;
                foreach (var childEllement in element.Descendants())
                {
                    context.Words.Add(new Word { Id = i, Name = childEllement.Value });
                    i++;
                }
            }

            context.SaveChanges();
        }
    }
}
