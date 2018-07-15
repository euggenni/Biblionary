using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblionary.Ninject;
using Ninject;
using Biblionary.BLL.Interface;
using Biblionary.Entities;

namespace Biblionary.IntegrationTests
{
    [TestClass]
    public class CommentLogicTests
    {
        [TestMethod]
        public void AddComment()
        {
            //NinjectComment.Registration();
            var logicComment = NinjectComment.Kernel.Get<ICommentLogic>();
            NinjectBook.Registration();
            var logicBook = NinjectComment.Kernel.Get<IBookLogic>();

            var newBook = new Book()
            {
                Title = "Test name",
                Author = "Test author",
                Genre = "Roman",
                Description = "Test description",
                Compiler = "Avatar",
            };
            //var idBook = logicBook.AddBook(newBook);

            //var newComment = new Comment()
            //{
            //    Book = idBook,
            //    User = "Avatar",
            //    Note = (float)7,
            //    Text = "Bla-bla-bla-bla",
            //};
            //logicComment.AddComment(newComment);
            //var allComments = logicComment.ReadComments(idBook);
            //Assert.AreEqual(allComments.Count(), 1, "Comment not added");
            //logicBook.DeleteBook(idBook);
        }

        [TestMethod]
        public void ReadComments()
        {
            //NinjectComment.Registration();
            var logicComment = NinjectComment.Kernel.Get<ICommentLogic>();
            var logicBook = NinjectComment.Kernel.Get<IBookLogic>();

            var newBook = new Book()
            {
                Title = "Test name",
                Author = "Test author",
                Genre = "Roman",
                Description = "Test description",
                Compiler = "Avatar",
            };
            var idBook = logicBook.AddBook(newBook);

            var newComment = new Comment()
            {
                Book = idBook,
                User = "Avatar",
                Note = (float)7,
                Text = "Bla-bla-bla-bla",
            };
            logicComment.AddComment(newComment);
            var allComments = logicComment.ReadComments(idBook);
            Assert.AreEqual(allComments.Count(), 1, "Comment not read");
            logicBook.DeleteBook(idBook);
        }
    }
}
