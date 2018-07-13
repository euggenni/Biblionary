using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Biblionary.Entities;
using Biblionary.BLL.Interface;
using Biblionary.DAL.Interface;

namespace Biblionary.BLL
{
    public class BookLogic: IBookLogic
    {
        private readonly IBiblionaryBookDao _bookDao;

        #region Constructor

        public BookLogic(IBiblionaryBookDao bookDao)
        {
            _bookDao = bookDao;
        }

        #endregion

        #region Methods

        public void AddBook(Book book)
        {
            _bookDao.AddBook(book);
        }

        public void DeleteBook(int id)
        {
            _bookDao.DeleteBook(id);
        }

        public void DeleteBook(string title)
        {
            _bookDao.DeleteBook(title);
        }

        public float GetAvgNote(int id)
        {
            return _bookDao.GetAvgNote(id);
        }

        public Book ReadBookFromid(int id)
        {
            return _bookDao.ReadBookFromid(id);
        }

        public IEnumerable<Book> ReadBooks()
        {
            return _bookDao.ReadBooks();
        }

        public IEnumerable<Book> SearchBooksFromAuthor(string author)
        {
            return _bookDao.SearchBooksFromAuthor(author);
        }

        public IEnumerable<Book> SearchBooksFromGenre(string genre)
        {
            return _bookDao.SearchBooksFromGenre(genre);
        }

        public IEnumerable<Book> SearchBooksFromTitle(string title)
        {
            return _bookDao.SearchBooksFromTitle(title);
        }

        public void UpdateBook(int id, Book book)
        {
            _bookDao.UpdateBook(id, book);
        }

        public void UpdateBook(string title, Book book)
        {
            _bookDao.UpdateBook(title, book);
        }

        #endregion
    }
}
