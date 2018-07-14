using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblionary.Entities;

namespace Biblionary.DAL.Interface
{
    public interface IBiblionaryUserDao
    {
        int Authorization(User user);

        User ReadUser(int id);

        User ReadUser(string login);

        IEnumerable<User> ReadUsers();

        int Registration(User user);

        void UpdatePassword(string login, string password);

        void UpdateRightsUser(int id, User user);

        void UpdateRightsUser(string login, User user);
    }
}
