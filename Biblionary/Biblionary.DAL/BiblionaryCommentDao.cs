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
    public class BiblionaryCommentDao: IBiblionaryCommentDao
    {
        private readonly string _connectionString;
        #region Constructor

        public BiblionaryCommentDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Biblionary.Properties.Settings.BibliConnectionString"].ConnectionString;
        }

        #endregion
        
        #region Члены IBiblionaryCommentDao

        public int AddComment(Comment comment)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddComment";

                    var idBook = new SqlParameter("@book", SqlDbType.Int) {Value = comment.Book};
                    command.Parameters.Add(idBook);
                    var user = new SqlParameter("@user", SqlDbType.VarChar) {Value = comment.User};
                    command.Parameters.Add(user);
                    var note = new SqlParameter("@note", SqlDbType.Float) {Value = comment.Note};
                    command.Parameters.Add(note);
                    var comm = new SqlParameter("@comment", SqlDbType.VarChar) {Value = comment.Text};
                    command.Parameters.Add(comm);

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

        public IEnumerable<Comment> ReadComments(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ReadComments";

                var idBook = new SqlParameter("@book", SqlDbType.Int) { Value = id };
                command.Parameters.Add(idBook);

                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new Comment
                    {
                        IdComment = (int)reader["ID_comment"],
                        Book = (int)reader["Book"],
                        User = (string)reader["Login"],
                        Note = (float)reader["Note"],
                        TimeAdd = ((DateTime)reader["TimeAdd"]).ToString(),
                        Text = (string)reader["Comment"],
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

        #endregion
    }
}
