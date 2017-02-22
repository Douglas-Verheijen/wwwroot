using Liquid.Home.UI.Configuration;
using Liquid.Home.UI.Models;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace Liquid.Home.UI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("ThankYou")]
        public ActionResult ThankYou()
        {
            return View();
        }
    }
}