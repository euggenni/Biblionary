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

        public void AddComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> ReadComments(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
