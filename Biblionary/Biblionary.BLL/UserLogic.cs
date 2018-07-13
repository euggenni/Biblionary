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
    public class UserLogic: IUserLogic
    {
        private readonly IBiblionaryUserDao _userDao;

        #region Constructor

        public UserLogic(IBiblionaryUserDao userDao)
        {
            _userDao = userDao;
        }

        #endregion
        #region Methods

        public int Authorization(User user)
        {
            return _userDao.Authorization(user);
        }

        public User ReadUser(int id)
        {
            return _userDao.ReadUser(id);
        }

        public User ReadUser(string login)
        {
            return _userDao.ReadUser(login);
        }

        public IEnumerable<User> ReadUsers()
        {
            return _userDao.ReadUsers();
        }

        public void Registration(User user)
        {
            _userDao.Registration(user);
        }

        public void UpdatePassword(string login, string password)
        {
            _userDao.UpdatePassword(login, password);
        }

        public void UpdateRightsUser(int id, User user)
        {
            _userDao.UpdateRightsUser(id, user);
        }

        public void UpdateRightsUser(string login, User user)
        {
            _userDao.UpdateRightsUser(login, user);
        }

        #endregion
    }
}
