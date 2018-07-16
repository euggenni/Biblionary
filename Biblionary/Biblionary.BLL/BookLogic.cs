using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Biblionary.Entities;
using Biblionary.BLL.Interface;
using Biblionary.DAL.Interface;
using log4net.Repository.Hierarchy;

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

        public int AddBook(Book book)
        {
            try
            {
                return _bookDao.AddBook(book);
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
                return 0;
            }
        }

        public void DeleteBook(int id)
        {
            try
            {
                _bookDao.DeleteBook(id);
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
            }
        }

        public void DeleteBook(string title)
        {
            try
            {
                _bookDao.DeleteBook(title);
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
            }
        }

        public int GetAvgNote(int id)
        {
            try
            {
                return _bookDao.GetAvgNote(id);
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
                return 0;
            }
        }

        public Book ReadBookFromid(int id)
        {
            try
            {
            return _bookDao.ReadBookFromid(id);
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
                return new Book();
            }
        }

        public IEnumerable<Book> ReadBooks()
        {
            try
            {
            return _bookDao.ReadBooks();
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
                return null;
            }
        }

        public IEnumerable<Book> SearchBooksFromAuthor(string author)
        {
            try
            {
            return _bookDao.SearchBooksFromAuthor(author);
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
                return null;
            }
        }

        public IEnumerable<Book> SearchBooksFromGenre(string genre)
        {
            try
            {
            return _bookDao.SearchBooksFromGenre(genre);
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
                return null;
            }
        }

        public IEnumerable<Book> SearchBooksFromTitle(string title)
        {
            try
            {
            return _bookDao.SearchBooksFromTitle(title);
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
                return null;
            }
        }

        public void UpdateBook(int id, Book book)
        {
            try
            {
            _bookDao.UpdateBook(id, book);
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
            }
        }

        public void UpdateBook(string title, Book book)
        {
            try
            {
            _bookDao.UpdateBook(title, book);
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
            }
        }

        #endregion
    }
}
