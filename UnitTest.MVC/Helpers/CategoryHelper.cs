using Store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.MVC.Helpers
{
    public static class CategoryHelper
	{
		public static Category createOneCategory()
		{
			return new Category()
			{
				CategoryID = 2,
				DateCreated = new DateTime(2019, 2, 1),
				Name = "Categoria 2",
			};
		}
		public static Category createOneCategoryWithGadget()
		{
			return new Category()
			{
				CategoryID = 1,
				DateCreated = new DateTime(2019, 1, 1),
				Name = "Categoria 1",
				Gadgets = new List<Gadget>() {
					new Gadget() { GadgetID = 1, Name = "Gadget 1", Description = "Descrizione 1", CategoryID = 1, Price = 10 },
					new Gadget() { GadgetID = 2, Name = "Gadget 2", Description = "Descrizione 2", CategoryID = 1, Price = 10 },
					new Gadget() { GadgetID = 3, Name = "Gadget 3", Description = "Descrizione 3", CategoryID = 1, Price = 10 },
				}
			};
		}
		public static List<Category> createTwoCategories()
		{
			List<Category> categories = new List<Category>();
			categories.Add(CategoryHelper.createOneCategoryWithGadget());
			categories.Add(CategoryHelper.createOneCategory());
			return categories;
        }
    }
}
