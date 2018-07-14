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
    public static class UserContainer
    {
        public static IBiblionaryUserDao UserDao = new BiblionaryUserDao();

        public static IUserLogic UserLogic = new UserLogic(UserDao);
    }
}
