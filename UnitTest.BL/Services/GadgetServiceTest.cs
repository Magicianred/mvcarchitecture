using NSubstitute;
using NUnit.Framework;
using Store.Data.Infrastructure;
using Store.Data.Repositories;
using Store.Model;
using Store.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.BL.Helpers;

namespace UnitTest.BL.Services
{
    [TestFixture]
    public class GadgetServiceTest
    {
        // private CategoryService _service;
        private GadgetService _sut;

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

            // _service = new CategoryService(_categoryRepFake, _unitOfWorkFake);
            _sut = new GadgetService(_gadgetRepFake, _categoryRepFake, _unitOfWorkFake);
        }

        [Test]
        public void should_return_three_gadgets()
        {

            // ARRANGE
            #region Arrange
            var gadgets = GadgetHelper.CreateFourGadgets();
            _gadgetRepFake.GetAll().Returns(gadgets);
            #endregion

            // ACT
            #region Act
            var result = _sut.GetGadgets();
            #endregion

            // ASSERT
            #region Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<Gadget>>(result);
            Assert.AreEqual(gadgets.Count(), result.Count());
            #endregion
        }

        [Test]
        public void should_return_data_gadget_id_four()
        {

            // ARRANGE
            #region Arrange
            var gadget = GadgetHelper.CreateGadgetFour();
            _gadgetRepFake.GetById(gadget.GadgetID).Returns(gadget);
            #endregion

            // ACT
            #region Act
            var result = _sut.GetGadget(4);
            #endregion

            // ASSERT
            #region Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Gadget>(result);
            Assert.AreEqual(gadget.CategoryID, result.CategoryID);
            Assert.AreEqual(gadget.Name, result.Name);
            #endregion
        }
    }
}
