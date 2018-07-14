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
            return _genreDao.AddGenre(genre);
        }

        public void DeleteGenre(int id)
        {
            _genreDao.DeleteGenre(id);
        }

        public void DeleteGenre(string name)
        {
            _genreDao.DeleteGenre(name);
        }

        public IEnumerable<Genre> ReadGenres()
        {
            return _genreDao.ReadGenres();
        }

        public void UpdateGenre(int id, Genre genre)
        {
            _genreDao.UpdateGenre(id, genre);
        }

        public void UpdateGenre(string name, Genre genre)
        {
            _genreDao.UpdateGenre(name, genre);
        }

        #endregion
    }
}
