using System.Web.Mvc;
using Telemedicine.Web.Attributes;

namespace Telemedicine.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {       
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}