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
            throw new NotImplementedException();
        }

        public void DeleteGenre(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteGenre(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Genre> ReadGenres()
        {
            throw new NotImplementedException();
        }

        public void UpdateGenre(int id, Genre genre)
        {
            throw new NotImplementedException();
        }

        public void UpdateGenre(string name, Genre genre)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
