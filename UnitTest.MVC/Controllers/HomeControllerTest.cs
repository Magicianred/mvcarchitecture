using NSubstitute;
using NUnit.Framework;
using Store.Data.Infrastructure;
using Store.Data.Repositories;
using Store.Model;
using Store.Service;
using Store.Web.Controllers;
using Store.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using UnitTest.MVC.Helpers;

namespace UnitTest.MVC.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        private HomeController _sut;

        private ICategoryService _categoryService;
        private IGadgetService _gadgetService;

        private IDbFactory _factoryFake;
        private IUnitOfWork _unitOfWorkFake;
        private IGadgetRepository _gadgetRepFake;
        private ICategoryRepository _categoryRepFake;

        [SetUp]
        public void setup()
        {
            _factoryFake = Substitute.For<IDbFactory>();
            _unitOfWorkFake = Substitute.For<IUnitOfWork>();
            _gadgetRepFake = Substitute.For<IGadgetRepository>();
            _categoryRepFake = Substitute.For<ICategoryRepository>();

            _categoryService = Substitute.For<ICategoryService>();
            _gadgetService = Substitute.For<IGadgetService>();

            _sut = new HomeController(_categoryService, _gadgetService);
        }

        [Test]
        [Ignore("TO FIX : problem with AutoMapper.AutoMapperMappingException : Missing type map configuration or unsupported mapping")]
        public void should_return_two_category_four_gadget()
        {
            // ARRANGE
            #region Arrange
            var categories = CategoryHelper.createTwoCategories();
            _categoryService.GetCategories().Returns(categories);
            #endregion

            // ACT
            #region Act

            var result = _sut.Index() as ViewResult;

            var items = (List<CategoryViewModel>)result.ViewData.Model;

            #endregion

            // ASSERT
            #region Assert

            // verify model returned is a TodoItemViewModel
            Assert.IsInstanceOf<IEnumerable<CategoryViewModel>>(result.ViewData.Model);

            // verify Names of items
            Assert.AreEqual(1, items.ElementAt(0).CategoryID);
            Assert.AreEqual(3, items.ElementAt(0).Gadgets.Count());
            Assert.AreEqual(2, items.ElementAt(1).CategoryID);
            Assert.AreEqual(1, items.ElementAt(1).Gadgets.Count());
            #endregion
        }

    }
}
