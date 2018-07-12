using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblionary.Entities;

namespace Biblionary.DAL.Interface
{
    public interface IBiblionaryDao
    {
        void AddBook(Book book);

        void AddComment(Comment comment);

        void AddGenre(Genre genre);

        int Authorization(User user);

        void DeleteBook(int id);

        void DeleteBook(string title);

        void DeleteGenre(int id);

        void DeleteGenre(string name);

        float GetAvgNote(int id);

        Book ReadBookFromid(int id);

        IEnumerable<Book> ReadBooks();

        IEnumerable<Comment> ReadComments(int id);

        IEnumerable<Genre> ReadGenres();

        User ReadUser(int id);

        User ReadUser(string login);

        IEnumerable<User> ReadUsers();

        void Registration(User user);

        IEnumerable<Book> SearchBooksFromAuthor(string author);

        IEnumerable<Book> SearchBooksFromGenre(string genre);

        IEnumerable<Book> SearchBooksFromTitle(string title);

        void UpdateBook(int id, Book book);

        void Updatebook(string title, Book book);

        void UpdateGenre(int id, Genre genre);

        void UpdateGenre(string name, Genre genre);

        void UpdatePassword(string login, string password);

        void UpdateRightsUser(int id, User user);

        void UpdateRightsUser(string login, User user);
    }
}
