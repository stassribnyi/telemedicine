using System.Web.Mvc;

namespace Telemedicine.Web.Controllers
{
    public class HomeController : Controller
    {       
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}