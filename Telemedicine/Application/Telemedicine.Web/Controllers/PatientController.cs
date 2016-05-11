using System.Web.Mvc;
using Telemedicine.Web.Attributes;

namespace Telemedicine.Web.Controllers
{
    //[Authorize]
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index(int patientId)
        {
            return View(patientId);
        }

        public ActionResult Analyze(int patientId)
        {
            return View(patientId);
        }

        public ActionResult New()
        {
            return View();
        }
    }
}