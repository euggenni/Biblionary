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
            try
            {
                return _userDao.Authorization(user);
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
                return 0;
            }
        }

        public User ReadUser(int id)
        {
            try
            {
                return _userDao.ReadUser(id);
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
                return new User();
            }
        }

        public User ReadUser(string login)
        {
            try
            {
                return _userDao.ReadUser(login);
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
                return new User();
            }
        }

        public IEnumerable<User> ReadUsers()
        {
            try
            {
                return _userDao.ReadUsers();
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
                return null;
            }
        }

        public int Registration(User user)
        {
            try
            {
                return _userDao.Registration(user);
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
                return 0;
            }
        }

        public void UpdatePassword(string login, string password)
        {
            try
            {
                _userDao.UpdatePassword(login, password);
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
            }
        }

        public void UpdateRightsUser(int id, User user)
        {
            try
            {
                _userDao.UpdateRightsUser(id, user);
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
            }
        }

        public void UpdateRightsUser(string login, User user)
        {
            try
            {
                _userDao.UpdateRightsUser(login, user);
            }
            catch (Exception ex)
            {
                LogBLL.Log.Error(ex.Message);
            }
        }

        #endregion
    }
}
