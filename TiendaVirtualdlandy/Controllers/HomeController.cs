using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TiendaVirtualdlandy.Controllers
{
    public class HomeController : Controller
    {
        //IServiceProvider iServiceProvider;
        /*public HomeController(IServiceProvider serviceProvider)
        {
            iServiceProvider = serviceProvider;
        }*/
        public ActionResult Index()
        {
            return View();
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