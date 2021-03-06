﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblionary.BLL;
using Biblionary.BLL.Interface;
using Biblionary.Container;
using Biblionary.Ninject;
using Biblionary.Entities;
using Ninject;

namespace Biblionary
{
    class Program
    {
        static void Main(string[] args)
        {
            NinjectBook.Registration();
            LogBLL.InitLogger();

            var bookLogic = NinjectBook.Kernel.Get<IBookLogic>();

            var id = bookLogic.AddBook(
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
            ///////
            var newBook = new Book()
            {
                Title = "Test name",
                Author = "Test author",
                Genre = "Roman",
                Description = "Test description",
                Compiler = "Avatar",
            };

            var ida = bookLogic.AddBook(newBook);
            var Book = bookLogic.ReadBookFromid(ida);
            /// 
            foreach (var book in bookLogic.ReadBooks())
            {
                Console.WriteLine(book.IdBook + " " + book.Title + " " + book.Author + " " + book.Genre + " " + book.Description + " " + book.Compiler + " " + book.DateAdd);
            }
            Console.WriteLine(id);
            Console.ReadKey();
        }
    }
}
