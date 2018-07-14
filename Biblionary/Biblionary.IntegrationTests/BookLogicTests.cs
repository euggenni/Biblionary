using System;
using Biblionary.Ninject;
using Ninject;
using Biblionary.DAL.Interface;
using Biblionary.BLL.Interface;
using Biblionary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Biblionary.IntegrationTests
{
    [TestClass]
    public class BookLogicTests
    {
        [TestMethod]
        public void AddBook()
        {
            NinjectBook.Registration();
            var logic = NinjectBook.Kernel.Get<IBookLogic>();

            var newBook = new Book()
            {
                Title = "Test name",
                Author = "Test author",
                Genre = "Roman",
                Description = "Test description",
                Compiler = "Avatar",
            };

            var id = logic.AddBook(newBook);
            var Book = logic.ReadBookFromid(id);
            Assert.IsNotNull(Book, "Book is null");
            Assert.AreEqual(newBook, Book, "Book not added");
        }
    }
}
