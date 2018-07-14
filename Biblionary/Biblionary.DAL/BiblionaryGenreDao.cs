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
    public class BiblionaryGenreDao: IBiblionaryGenreDao
    {
        private readonly string _connectionString;
        #region Constructor

        public BiblionaryGenreDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Biblionary.Properties.Settings.BibliConnectionString"].ConnectionString;
        }

        #endregion
        
        #region Члены IBiblionaryGenreDao

        public void AddGenre(Genre genre)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AddGenre";

                var name = new SqlParameter("@name", SqlDbType.VarChar) { Value = genre.Name };
                command.Parameters.Add(name);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteGenre(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeleteGenreFromID";

                var idGenre = new SqlParameter("@genre", SqlDbType.Int) { Value = id };
                command.Parameters.Add(idGenre);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteGenre(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeleteGenreFromName";

                var nam = new SqlParameter("@name", SqlDbType.VarChar) { Value = name };
                command.Parameters.Add(nam);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Genre> ReadGenres()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ReadGenres";

                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new Genre
                    {
                        IdGenre = (int)reader["ID_genre"],
                        Name = (string)reader["Name"],
                    };
                }
            }
        }

        public void UpdateGenre(int id, Genre genre)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateGenreFromID";

                var genr = new SqlParameter("@genre", SqlDbType.Int) { Value = id };
                command.Parameters.Add(genr);
                var name = new SqlParameter("@name", SqlDbType.VarChar) { Value = genre.Name };
                command.Parameters.Add(name);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateGenre(string name, Genre genre)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateGenreFromName";

                var oldName = new SqlParameter("@oldName", SqlDbType.VarChar) { Value = name };
                command.Parameters.Add(oldName);
                var newName = new SqlParameter("@newName", SqlDbType.VarChar) { Value = genre.Name };
                command.Parameters.Add(newName);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        #endregion
    }
}
