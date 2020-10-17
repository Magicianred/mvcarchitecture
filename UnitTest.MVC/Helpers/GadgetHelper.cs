using Store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.MVC.Helpers
{
    public static class GadgetHelper
    {
        public static Gadget CreateGadgetOne()
        {
            return new Gadget() { GadgetID = 1, Name = "Gadget 1", Description = "Descrizione 1", CategoryID = 1, Price = 10 };
        }
        public static Gadget CreateGadgetTwo()
        {
            return new Gadget() { GadgetID = 2, Name = "Gadget 2", Description = "Descrizione 2", CategoryID = 1, Price = 10 };
        }
        public static Gadget CreateGadgetThree()
        {
            return new Gadget() { GadgetID = 3, Name = "Gadget 3", Description = "Descrizione 3", CategoryID = 1, Price = 10 };
        }
        public static Gadget CreateGadgetFour()
        {
            return new Gadget() { GadgetID = 4, Name = "Gadget 4", Description = "Descrizione 4", CategoryID = 2, Price = 20 };
        }
        public static List<Gadget> CreateFourGadgets()
        {
            return new List<Gadget>()
            {
                GadgetHelper.CreateGadgetOne(),
                GadgetHelper.CreateGadgetTwo(),
                GadgetHelper.CreateGadgetThree(),
                GadgetHelper.CreateGadgetFour(),
            };
        }
    }
}
