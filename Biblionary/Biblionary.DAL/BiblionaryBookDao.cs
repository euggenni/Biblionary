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

        public int AddBook(Book book)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
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
                    return (int)(decimal)command.ExecuteScalar();
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public void DeleteBook(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeleteBookFromID";

                var idBook = new SqlParameter("@book", SqlDbType.Int) {Value = id};
                command.Parameters.Add(idBook);

                connection.Open();
                command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public void DeleteBook(string title)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeleteBookFromTitle";

                var titl = new SqlParameter("@title", SqlDbType.VarChar) {Value = title};
                command.Parameters.Add(titl);

                connection.Open();
                command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public int GetAvgNote(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAvgNote";

                var idBook = new SqlParameter("@book", SqlDbType.Int) {Value = id};
                command.Parameters.Add(idBook);

                connection.Open();
                return (int)(decimal)command.ExecuteScalar();
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public Book ReadBookFromid(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ReadBookFromID";

                var idBook = new SqlParameter("@book", SqlDbType.Int) {Value = id};
                command.Parameters.Add(idBook);

                connection.Open();

                var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Book()
                        {
                            IdBook = (int) reader["ID_book"],
                            Title = (string) reader["Title"],
                            Author = (string) reader["Author"],
                            Genre = (string) reader["Genre"],
                            Description = (string) reader["Description"],
                            Compiler = (string) reader["Login"],
                            DateAdd = ((DateTime) reader["Date_add"]).ToString(),
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public IEnumerable<Book> ReadBooks()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
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
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public IEnumerable<Book> SearchBooksFromAuthor(string author)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SearchBooksFromAuthor";

                var auth = new SqlParameter("@author", SqlDbType.VarChar) { Value = author };
                command.Parameters.Add(auth);

                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new Book
                    {
                        IdBook = (int)reader["ID_book"],
                        Title = (string)reader["Title"],
                        Author = (string)reader["Author"],
                        Genre = (string)reader["Genre"],
                        Description = (string)reader["Description"],
                        Compiler = (string)reader["Login"],
                        DateAdd = ((DateTime)reader["Date_add"]).ToString(),
                    };
                }
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public IEnumerable<Book> SearchBooksFromGenre(string genre)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SearchBooksFromGenre";

                var genr = new SqlParameter("@genre", SqlDbType.VarChar) { Value = genre };
                command.Parameters.Add(genr);

                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new Book
                    {
                        IdBook = (int)reader["ID_book"],
                        Title = (string)reader["Title"],
                        Author = (string)reader["Author"],
                        Genre = (string)reader["Genre"],
                        Description = (string)reader["Description"],
                        Compiler = (string)reader["Login"],
                        DateAdd = ((DateTime)reader["Date_add"]).ToString(),
                    };
                }
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public IEnumerable<Book> SearchBooksFromTitle(string title)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SearchBooksFromTitle";

                var titl = new SqlParameter("@title", SqlDbType.VarChar) { Value = title };
                command.Parameters.Add(titl);

                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new Book
                    {
                        IdBook = (int)reader["ID_book"],
                        Title = (string)reader["Title"],
                        Author = (string)reader["Author"],
                        Genre = (string)reader["Genre"],
                        Description = (string)reader["Description"],
                        Compiler = (string)reader["Login"],
                        DateAdd = ((DateTime)reader["Date_add"]).ToString(),
                    };
                }
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public void UpdateBook(int id, Book book)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateBookFromID";

                var idBook = new SqlParameter("@book", SqlDbType.Int) { Value = id };
                command.Parameters.Add(idBook);

                var title = new SqlParameter("@title", SqlDbType.VarChar) { Value = book.Title };
                command.Parameters.Add(title);
                var author = new SqlParameter("@author", SqlDbType.VarChar) { Value = book.Author };
                command.Parameters.Add(author);
                var genre = new SqlParameter("@genre", SqlDbType.VarChar) { Value = book.Genre };
                command.Parameters.Add(genre);
                var description = new SqlParameter("@description", SqlDbType.VarChar) { Value = book.Description };
                command.Parameters.Add(description);

                connection.Open();
                command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public void UpdateBook(string title, Book book)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateBookFromTitle";

                var idBook = new SqlParameter("@oldTitle", SqlDbType.VarChar) { Value = title };
                command.Parameters.Add(idBook);

                var titl = new SqlParameter("@newTitle", SqlDbType.VarChar) { Value = book.Title };
                command.Parameters.Add(titl);
                var author = new SqlParameter("@author", SqlDbType.VarChar) { Value = book.Author };
                command.Parameters.Add(author);
                var genre = new SqlParameter("@genre", SqlDbType.VarChar) { Value = book.Genre };
                command.Parameters.Add(genre);
                var description = new SqlParameter("@description", SqlDbType.VarChar) { Value = book.Description };
                command.Parameters.Add(description);

                connection.Open();
                command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        #endregion
    }
}
