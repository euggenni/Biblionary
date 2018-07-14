using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblionary.Entities;

namespace Biblionary.DAL.Interface
{
    public interface IBiblionaryBookDao
    {
        int AddBook(Book book);

        void DeleteBook(int id);

        void DeleteBook(string title);

        float GetAvgNote(int id);

        Book ReadBookFromid(int id);

        IEnumerable<Book> ReadBooks();

        IEnumerable<Book> SearchBooksFromAuthor(string author);

        IEnumerable<Book> SearchBooksFromGenre(string genre);

        IEnumerable<Book> SearchBooksFromTitle(string title);

        void UpdateBook(int id, Book book);

        void UpdateBook(string title, Book book);
    }
}
