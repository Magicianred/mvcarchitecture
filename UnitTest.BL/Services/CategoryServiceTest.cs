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
	public class CategoryServiceTest
	{
		private CategoryService _sut;

		private IDbFactory _factoryFake;
		private IUnitOfWork _unitOfWorkFake;
		private ICategoryRepository _categoryRepFake;

		[SetUp]
		public void setup()
		{
			_factoryFake = Substitute.For<IDbFactory>();
			_unitOfWorkFake = Substitute.For<IUnitOfWork>();
			_categoryRepFake = Substitute.For<ICategoryRepository>();


			_sut = new CategoryService(_categoryRepFake, _unitOfWorkFake);
		}

		[Test]
		public void should_return_two_categories() {

			// ARRANGE
			#region Arrange
			var categories = CategoryHelper.createTwoCategories();
			_categoryRepFake.GetAll().Returns(categories);
			#endregion

			// ACT
			#region Act
			var result = _sut.GetCategories();
			#endregion

			// ASSERT
			#region Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOf<IEnumerable<Category>>(result);
			Assert.AreEqual(2, result.Count());
			#endregion
		}

		[Test]
		public void should_return_one_category_byName()
		{

			// ARRANGE
			#region Arrange
			var categoryName = "Categoria 2";
			var categories = CategoryHelper.createTwoCategories();
			_categoryRepFake.GetAll().Returns(categories);
			#endregion

			// ACT
			#region Act
			var result = _sut.GetCategories(categoryName);
			#endregion

			// ASSERT
			#region Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOf<IEnumerable<Category>>(result);
			Assert.AreEqual(1, result.Count());
			var categoriesResult = result.ToList();
			Assert.AreEqual(categoryName, categoriesResult[0].Name);
			#endregion
		}

        [Test]
        public void should_return_data_category_id_one()
        {

			// ARRANGE
			#region Arrange
			var id = 1;
			var category = CategoryHelper.createOneCategoryWithGadget();
			_categoryRepFake.GetById(id).Returns(category);
			#endregion

			// ACT
			#region Act
			var result = _sut.GetCategory(1);
            #endregion

            // ASSERT
            #region Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Category>(result);
            Assert.AreEqual(1, result.CategoryID);
            Assert.AreEqual("Categoria 1", result.Name);
            Assert.AreEqual(3, result.Gadgets.Count());
            #endregion
        }

    }
}
