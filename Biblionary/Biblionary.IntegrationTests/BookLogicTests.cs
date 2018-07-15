using System;
using System.Linq;
using Biblionary.Ninject;
using Biblionary.Container;
using Ninject;
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
            Assert.AreEqual(newBook.Description, Book.Description, "Book not added");
            logic.DeleteBook(id);
        }

        [TestMethod]
        public void DeleteBook()
        {
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
            logic.DeleteBook(id);
            var Book = logic.ReadBookFromid(id);
            Assert.IsNull(Book, "Book not deleted by ID");

            logic.AddBook(newBook);
            logic.DeleteBook(newBook.Title);
            var Book2 = logic.ReadBookFromid(id);
            Assert.IsNull(Book2, "Book not deleted by Title");
        }

        [TestMethod]
        public void GetAvgNote()
        {
            var logicBook = NinjectBook.Kernel.Get<IBookLogic>();
            NinjectComment.Registration();
            var logicComment = NinjectComment.Kernel.Get<ICommentLogic>();

            var newBook = new Book()
            {
                Title = "Test name",
                Author = "Test author",
                Genre = "Roman",
                Description = "Test description",
                Compiler = "Avatar",
            };
            var idBook = logicBook.AddBook(newBook);
            var newComment1 = new Comment()
            {
                Book = idBook,
                User = "Avatar",
                Note =  (float) 7,
                Text = "Bla-bla-bla-bla",
            };
            var newComment2 = new Comment()
            {
                Book = idBook,
                User = "Avatar",
                Note = (float) 6,
                Text = "Blu-blu-blu-blu",
            };
            logicComment.AddComment(newComment1);
            logicComment.AddComment(newComment2);
            int note = logicBook.GetAvgNote(idBook);
            Assert.AreEqual(note, 7, "Avg note is not valid");
        }

        [TestMethod]
        public void ReadBookFromID()
        {
            //NinjectBook.Registration();
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
            Assert.AreEqual(newBook.Description, Book.Description, "Book not correct read");
            logic.DeleteBook(id); 
        }

        [TestMethod]
        public void ReadBooks()
        {
            //NinjectBook.Registration();
            var logic = NinjectBook.Kernel.Get<IBookLogic>();

            var Books = logic.ReadBooks();
            Assert.IsTrue(Books.Any(), "Books not read");
        }

        [TestMethod]
        public void SearchBooks()
        {
            //NinjectBook.Registration();
            var logic = NinjectBook.Kernel.Get<IBookLogic>();
            var newBook1 = new Book()
            {
                Title = "Super test name",
                Author = "Super test author",
                Genre = "Novella",
                Description = "Test description",
                Compiler = "Avatar",
            };
            var newBook2 = new Book()
            {
                Title = "Super test name",
                Author = "Super test author",
                Genre = "Novella",
                Description = "Test description",
                Compiler = "Avatar",
            };
            var id1 = logic.AddBook(newBook1);
            var id2 = logic.AddBook(newBook2);
            var Books1 = logic.SearchBooksFromAuthor("Super test author");
            var Books2 = logic.SearchBooksFromGenre("Novella");
            var Books3 = logic.SearchBooksFromTitle("Super test name");
            Assert.AreEqual(Books1.Count(), 2, "Books not read by author");
            Assert.AreEqual(Books2.Count(), 2, "Books not read by genre");
            Assert.AreEqual(Books3.Count(), 2, "Books not read by title");
            logic.DeleteBook(id1);
            logic.DeleteBook(id2);
        }

        [TestMethod]
        public void UpdateBook()
        {
            //NinjectBook.Registration();
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
            var newBook2 = new Book()
            {
                Title = "Test name2",
                Author = "Test author2",
                Genre = "Novella",
                Description = "Test description2",
                Compiler = "Avatar",
            };
            logic.UpdateBook(id, newBook2);
            var updatedBook = logic.ReadBookFromid(id);
            Assert.AreEqual(newBook2.Title, updatedBook.Title, "Not updated title");
            Assert.AreEqual(newBook2.Author, updatedBook.Author, "Not updated author");
            Assert.AreEqual(newBook2.Genre, updatedBook.Genre, "Not updated genre");
            Assert.AreEqual(newBook2.Description, updatedBook.Description, "Not updated description");
            logic.DeleteBook(id);
        }
    }
}
