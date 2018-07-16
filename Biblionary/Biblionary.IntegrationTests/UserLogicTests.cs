using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblionary.Ninject;
using Ninject;
using Biblionary.BLL.Interface;
using Biblionary.Entities;

namespace Biblionary.IntegrationTests
{
    [TestClass]
    public class UserLogicTests
    {
        [TestMethod]
        public void Authorization()
        {
            NinjectUser.Registration();
            var logic = NinjectUser.Kernel.Get<IUserLogic>();

            var Authorization = new User()
            {
                Login = "Avatar",
                Password = "1111",
            };
            var idUser = logic.Authorization(Authorization);
            var User = logic.ReadUser(idUser);

            Assert.IsNotNull(User, "Failed authorization");
        }

        [TestMethod]
        public void ReadUser()
        {
            //NinjectUser.Registration();
            var logic = NinjectUser.Kernel.Get<IUserLogic>();

            var newUser = new User()
            {
                Login = "Testor User",
                Password = "Testsss",
            };
            var idUser = logic.Registration(newUser);
            var user = logic.ReadUser(idUser);
            Assert.AreEqual(newUser.Password, user.Password, "User not readed by id");
            user = logic.ReadUser(newUser.Login);
            Assert.AreEqual(newUser.Password, user.Password, "User not readed by login");
        }

        [TestMethod]
        public void ReadUsers()
        {
            //NinjectUser.Registration();
            var logic = NinjectUser.Kernel.Get<IUserLogic>();

            var newUser = new User()
            {
                Login = "Testorator User",
                Password = "Testsss",
            };

            var idUser = logic.Registration(newUser);
            var Users = logic.ReadUsers();
            var User = logic.ReadUser(idUser);
            Assert.IsTrue(Users.Contains(User), "Users not readed");
        }

        [TestMethod]
        public void Registration()
        {
            //NinjectUser.Registration();
            var logic = NinjectUser.Kernel.Get<IUserLogic>();

            var newUser = new User()
            {
                Login = "Test User",
                Password = "Testsss",
            };
            var idUser = logic.Registration(newUser);
            var User = logic.ReadUser(idUser);
            Assert.IsNotNull(User, "User not registred");
        }

        [TestMethod]
        public void UpdatePassword()
        {
            //NinjectUser.Registration();
            var logic = NinjectUser.Kernel.Get<IUserLogic>();

            var newUser = new User()
            {
                Login = "Test User",
                Password = "Testsss",
            };
            var idUser = logic.Registration(newUser);
            newUser.Password = "top secret";
            logic.UpdatePassword(newUser.Login, newUser.Password);
            var updatedUser = logic.ReadUser(idUser);
            Assert.AreEqual(newUser.Password, updatedUser.Password, "Password not updated");
        }

        [TestMethod]
        public void UpdateRightsUser()
        {
            //NinjectUser.Registration();
            var logic = NinjectUser.Kernel.Get<IUserLogic>();

            var newUser = new User()
            {
                Login = "Super test User",
                Password = "Test",
            };
            var idUser = logic.Registration(newUser);
            newUser.Type = "Administrator";
            //newUser.CanComment = false;
            //newUser.CanRead = false;
            newUser.Rights = (byte) (User.UserRole.None);
            logic.UpdateRightsUser(idUser, newUser);
            var PuperUser = logic.ReadUser(idUser);
            Assert.AreEqual(newUser.Type, PuperUser.Type, "Type user not updated by id");
            Assert.AreEqual(newUser.Rights, PuperUser.Rights, "Rights user not updated by id");
            newUser.Type = "Moderator";
            newUser.Rights = (byte)(User.UserRole.CanComment | User.UserRole.CanRead);
            logic.UpdateRightsUser(newUser.Login, newUser);
            PuperUser = logic.ReadUser(idUser);
            Assert.AreEqual(newUser.Type, PuperUser.Type, "Type user not updated by login");
            Assert.AreEqual(newUser.Rights, PuperUser.Rights, "Rights user not updated by login");
        }
    }
}
