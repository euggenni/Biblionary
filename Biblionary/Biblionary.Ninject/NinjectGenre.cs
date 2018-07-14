using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Biblionary.DAL;
using Biblionary.DAL.Interface;
using Biblionary.BLL;
using Biblionary.BLL.Interface;

namespace Biblionary.Ninject
{
    public static class NinjectGenre
    {
        #region Fields

        private static readonly IKernel _kernel = new StandardKernel();

        #endregion

        #region Properties

        public static IKernel Kernel
        {
            get { return _kernel; }
        }

        #endregion

        #region Methods

        public static void Registration()
        {
            _kernel.Bind<IBiblionaryGenreDao>().To<BiblionaryGenreDao>();
            _kernel.Bind<IGenreLogic>().To<GenreLogic>();
        }

        #endregion

    }
}
