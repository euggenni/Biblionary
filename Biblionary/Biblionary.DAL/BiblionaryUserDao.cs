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
            throw new NotImplementedException();
        }

        public User ReadUser(int id)
        {
            throw new NotImplementedException();
        }

        public User ReadUser(string login)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> ReadUsers()
        {
            throw new NotImplementedException();
        }

        public void Registration(User user)
        {
            throw new NotImplementedException();
        }

        public void UpdatePassword(string login, string password)
        {
            throw new NotImplementedException();
        }

        public void UpdateRightsUser(int id, User user)
        {
            throw new NotImplementedException();
        }

        public void UpdateRightsUser(string login, User user)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
