using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblionary.BLL;
using Biblionary.BLL.Interface;
using Biblionary.DAL;
using Biblionary.DAL.Interface;

namespace Biblionary.Container
{
    class GenreContainer
    {
        public static IBiblionaryGenreDao GenreDao = new BiblionaryGenreDao();

        public static IGenreLogic GenreLogic = new GenreLogic(GenreDao);
    }
}
