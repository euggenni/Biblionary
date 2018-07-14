using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblionary.Entities;
using Biblionary.DAL.Interface;

namespace Biblionary.DAL
{
    public class BiblionaryBookDao: IBiblionaryBookDao
    {
        private readonly string _connectionString;
        #region Constructor

        public BiblionaryBookDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Biblionary.Properties.Settings.BibliConnectionString"].ConnectionString;
        }

        #endregion
        
        #region Члены IBiblionaryBookDao

        public void AddBook(Book book)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AddBook";

                var title = new SqlParameter("@title", SqlDbType.VarChar) {Value = book.Title};
                command.Parameters.Add(title);
                var author = new SqlParameter("@author", SqlDbType.VarChar) {Value = book.Author};
                command.Parameters.Add(author);
                var genre = new SqlParameter("@genre", SqlDbType.VarChar) {Value = book.Genre};
                command.Parameters.Add(genre);
                var description = new SqlParameter("@description", SqlDbType.VarChar) {Value = book.Description};
                command.Parameters.Add(description);
                var compiler = new SqlParameter("@compiler", SqlDbType.VarChar) {Value = book.Compiler};
                command.Parameters.Add(compiler);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteBook(int id)
        {
            
        }

        public void DeleteBook(string title)
        {
            throw new NotImplementedException();
        }

        public float GetAvgNote(int id)
        {
            throw new NotImplementedException();
        }

        public Book ReadBookFromid(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> ReadBooks()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ReadBooks";

                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new Book
                    {
                        IdBook = (int) reader["ID_book"],
                        Title = (string) reader["Title"],
                        Author = (string) reader["Author"],
                        Genre = (string) reader["Genre"],
                        Description = (string) reader["Description"],
                        Compiler = (string) reader["Login"],
                        DateAdd = ((DateTime)reader["Date_add"]).ToString(),
                    };
                }
            }
        }

        public IEnumerable<Book> SearchBooksFromAuthor(string author)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> SearchBooksFromGenre(string genre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> SearchBooksFromTitle(string title)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(int id, Book book)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(string title, Book book)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
