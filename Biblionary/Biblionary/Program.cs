using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblionary.Container;
using Biblionary.Entities;

namespace Biblionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookLogic = BookContainer.BookLogic;

            bookLogic.AddBook(
                new Book()
                {
                    IdBook = 0,
                    Title = "Var-var-var",
                    Author = "Turgenev",
                    Genre = "Roman",
                    Description = "bla-bla-bla-bla-bla",
                    Compiler = "Avatar",
                    DateAdd = (new DateTime(2018, 08, 08, 21, 22, 24)).ToString(),
                }
                );
            //bookLogic.DeleteBook("Var-var-var");

            foreach (var book in bookLogic.ReadBooks())
            {
                Console.WriteLine(book.IdBook + " " + book.Title + " " + book.Author + " " + book.Genre + " " + book.Description + " " + book.Compiler + " " + book.DateAdd);
            }

            Console.ReadKey();
        }
    }
}
