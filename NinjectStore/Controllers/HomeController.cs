using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

using NinjectStore.Models;

namespace NinjectStore.Controllers
{
    public class HomeController : Controller
    {
        private Product[] products = new Product[]
        {
            new Product {Name = "Kayak", Category = "Water-sports", Price = 275M },
            new Product {Name = "LifeJacket", Category = "Water-sports", Price = 48.9M },
            new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M },
            new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M }
        };

        public ActionResult Index()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            IValueCalculator calc = ninjectKernel.Get<IValueCalculator>();

            ShoppingCart cart = new ShoppingCart(calc) { Products = products };

            decimal totalValue = cart.CalculateProductTotal();
            return View(totalValue);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}