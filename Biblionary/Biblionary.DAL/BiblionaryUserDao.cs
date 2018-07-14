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
    public class BiblionaryUserDao: IBiblionaryUserDao
    {
        private readonly string _connectionString;
        #region Constructor

        public BiblionaryUserDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Biblionary.Properties.Settings.BibliConnectionString"].ConnectionString;
        }

        #endregion
        
        #region Члены IBiblionaryUserDao

        public int Authorization(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Authorization";

                    var login = new SqlParameter("@login", SqlDbType.VarChar) {Value = user.Login};
                    command.Parameters.Add(login);
                    var password = new SqlParameter("@password", SqlDbType.VarChar) {Value = user.Password};
                    command.Parameters.Add(password);

                    connection.Open();
                    return (int) (decimal) command.ExecuteScalar();
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public User ReadUser(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ReadUserFromID";

                var idUser = new SqlParameter("@id_user", SqlDbType.Int) { Value = id };
                command.Parameters.Add(idUser);

                connection.Open();

                var reader = command.ExecuteReader();
                reader.Read();
                return new User
                {
                    IdUser = (int)reader["ID_user"],
                    Login = (string)reader["Login"],
                    Password = (string)reader["Password"],
                    Type = (string)reader["Type"],
                    DateReg = ((DateTime)reader["Date_reg"]).ToString(),
                    CanComment = (bool)reader["Can_comment"],
                    CanRead = (bool)reader["Can_read"],
                };
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public User ReadUser(string login)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ReadUserFromLogin";

                var logi = new SqlParameter("@login", SqlDbType.VarChar) { Value = login };
                command.Parameters.Add(logi);

                connection.Open();

                var reader = command.ExecuteReader();
                reader.Read();
                return new User
                {
                    IdUser = (int)reader["ID_user"],
                    Login = (string)reader["Login"],
                    Password = (string)reader["Password"],
                    Type = (string)reader["Type"],
                    DateReg = ((DateTime)reader["Date_reg"]).ToString(),
                    CanComment = (bool)reader["Can_comment"],
                    CanRead = (bool)reader["Can_read"],
                };
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public IEnumerable<User> ReadUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ReadUsers";

                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new User
                    {
                        IdUser = (int) reader["ID_user"],
                        Login = (string) reader["Login"],
                        Password = (string) reader["Password"],
                        Type = (string) reader["Type"],
                        DateReg = ((DateTime) reader["Date_reg"]).ToString(),
                        CanComment = (bool) reader["Can_comment"],
                        CanRead = (bool) reader["Can_read"],
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

        public int Registration(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Registration";

                var login = new SqlParameter("@login", SqlDbType.VarChar) { Value = user.Login };
                command.Parameters.Add(login);
                var password = new SqlParameter("@password", SqlDbType.VarChar) { Value = user.Password };
                command.Parameters.Add(password);

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

        public void UpdatePassword(string login, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdatePassword";

                var logi = new SqlParameter("@login", SqlDbType.VarChar) { Value = login };
                command.Parameters.Add(logi);
                var pass = new SqlParameter("@password", SqlDbType.VarChar) { Value = password };
                command.Parameters.Add(pass);

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

        public void UpdateRightsUser(int id, User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateRightsUserFromID";

                var idUser = new SqlParameter("@user", SqlDbType.Int) { Value = id };
                command.Parameters.Add(idUser);
                var type = new SqlParameter("@type", SqlDbType.VarChar) { Value = user.Type };
                command.Parameters.Add(type);
                var canComment = new SqlParameter("@can_comment", SqlDbType.Bit) { Value = user.CanComment};
                command.Parameters.Add(canComment);
                var canRead = new SqlParameter("@can_read", SqlDbType.Bit) { Value = user.CanRead };
                command.Parameters.Add(canRead);

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

        public void UpdateRightsUser(string login, User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateRightsUserFromLogin";

                var logi = new SqlParameter("@login", SqlDbType.Int) { Value = login };
                command.Parameters.Add(logi);
                var type = new SqlParameter("@type", SqlDbType.VarChar) { Value = user.Type };
                command.Parameters.Add(type);
                var canComment = new SqlParameter("@can_comment", SqlDbType.Bit) { Value = user.CanComment };
                command.Parameters.Add(canComment);
                var canRead = new SqlParameter("@can_read", SqlDbType.Bit) { Value = user.CanRead };
                command.Parameters.Add(canRead);

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
