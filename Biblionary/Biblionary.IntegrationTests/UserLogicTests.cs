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


        }

        [TestMethod]
        public void ReadUser()
        {
            //NinjectUser.Registration();
            var logic = NinjectUser.Kernel.Get<IUserLogic>();


        }

        [TestMethod]
        public void ReadUsers()
        {
            //NinjectUser.Registration();
            var logic = NinjectUser.Kernel.Get<IUserLogic>();


        }

        [TestMethod]
        public void Registration()
        {
            //NinjectUser.Registration();
            var logic = NinjectUser.Kernel.Get<IUserLogic>();


        }

        [TestMethod]
        public void UpdatePassword()
        {
            //NinjectUser.Registration();
            var logic = NinjectUser.Kernel.Get<IUserLogic>();


        }

        [TestMethod]
        public void UpdateRightsUser()
        {
            //NinjectUser.Registration();
            var logic = NinjectUser.Kernel.Get<IUserLogic>();


        }
    }
}
