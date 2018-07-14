using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblionary.Entities;

namespace Biblionary.BLL.Interface
{
    public interface IGenreLogic
    {
        int AddGenre(Genre genre);

        void DeleteGenre(int id);

        void DeleteGenre(string name);

        IEnumerable<Genre> ReadGenres();

        void UpdateGenre(int id, Genre genre);

        void UpdateGenre(string name, Genre genre);
    }
}
