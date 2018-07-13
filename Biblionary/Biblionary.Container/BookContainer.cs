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
    public class BookContainer
    {
        public static IBiblionaryBookDao BookDao = new BiblionaryBookDao();

        public static IBookLogic BookLogic = new BookLogic(BookDao);
    }
}
