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
    public class GenreLogicTests
    {
        [TestMethod]
        public void AddGenre()
        {
            NinjectGenre.Registration();
            var logic = NinjectGenre.Kernel.Get<IGenreLogic>();

            var newGenre = new Genre()
            {
                Name = "Test genre",
            };
            var idGenre = logic.AddGenre(newGenre);
            var allGenres = logic.ReadGenres();
            Assert.IsTrue(allGenres.Contains(new Genre(){IdGenre = idGenre, Name = newGenre.Name}), "Genre not added");
            logic.DeleteGenre(idGenre);
        }

        [TestMethod]
        public void DeleteGenre()
        {
            //NinjectGenre.Registration();
            var logic = NinjectGenre.Kernel.Get<IGenreLogic>();

            var newGenre = new Genre()
            {
                Name = "Test genre",
            };
            var idGenre = logic.AddGenre(newGenre);
            logic.DeleteGenre(idGenre);
            var allGenres = logic.ReadGenres();
            Assert.IsFalse(allGenres.Contains(new Genre() { IdGenre = idGenre, Name = newGenre.Name }), "Genre not deleted by id");
            idGenre = logic.AddGenre(newGenre);
            logic.DeleteGenre(newGenre.Name);
            allGenres = logic.ReadGenres();
            Assert.IsFalse(allGenres.Contains(new Genre() { IdGenre = idGenre, Name = newGenre.Name }), "Genre not deleted by Name");

        }

        [TestMethod]
        public void ReadGenres()
        {
            //NinjectGenre.Registration();
            var logic = NinjectGenre.Kernel.Get<IGenreLogic>();
            var newGenre = new Genre()
            {
                Name = "Test genre",
            };
            var idGenre = logic.AddGenre(newGenre);
            Assert.IsTrue(logic.ReadGenres().Contains(new Genre(){IdGenre = idGenre, Name = newGenre.Name}), "Genres is not read");
            logic.DeleteGenre(idGenre);
        }

        [TestMethod]
        public void UpdateGenre()
        {
            //NinjectGenre.Registration();
            var logic = NinjectGenre.Kernel.Get<IGenreLogic>();

            var newGenre = new Genre()
            {
                Name = "Test genre",
            };
            var idGenre = logic.AddGenre(newGenre);
            var newGenre2 = new Genre()
            {
                Name = "Super test genre",
            };
            logic.UpdateGenre(idGenre, newGenre2);
            var allGenres = logic.ReadGenres();
            Assert.IsTrue(allGenres.Contains(new Genre(){IdGenre = idGenre, Name = newGenre2.Name}), "Genre not updated by id");
            logic.DeleteGenre(idGenre);
            idGenre = logic.AddGenre(newGenre);
            logic.UpdateGenre(newGenre.Name, newGenre2);
            allGenres = logic.ReadGenres();
            Assert.IsTrue(allGenres.Contains(new Genre(){IdGenre = idGenre, Name = newGenre2.Name}), "Genre not updated by name");
        }
    }
}
