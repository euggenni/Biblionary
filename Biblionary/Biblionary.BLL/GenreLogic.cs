using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblionary.Entities;
using Biblionary.BLL.Interface;
using Biblionary.DAL.Interface;

namespace Biblionary.BLL
{
    public class GenreLogic: IGenreLogic
    {
        private readonly IBiblionaryGenreDao _genreDao;
        #region Constructor

        public GenreLogic(IBiblionaryGenreDao genreDao)
        {
            _genreDao = genreDao;
        }

        #endregion
        
        #region Methods

        public int AddGenre(Genre genre)
        {
            try
            {
                return _genreDao.AddGenre(genre);
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
                return 0;
            }
        }

        public void DeleteGenre(int id)
        {
            try
            {
                _genreDao.DeleteGenre(id);
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
            }
        }

        public void DeleteGenre(string name)
        {
            try
            {
                _genreDao.DeleteGenre(name);
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
            }
        }

        public IEnumerable<Genre> ReadGenres()
        {
            try
            {
                return _genreDao.ReadGenres();
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
                return null;
            }
        }

        public void UpdateGenre(int id, Genre genre)
        {
            try
            {
                _genreDao.UpdateGenre(id, genre);
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
            }
        }

        public void UpdateGenre(string name, Genre genre)
        {
            try
            {
                _genreDao.UpdateGenre(name, genre);
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
            }
        }

        #endregion
    }
}
