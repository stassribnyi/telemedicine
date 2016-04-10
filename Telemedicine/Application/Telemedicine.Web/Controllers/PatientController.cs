using System.Web.Mvc;

namespace Telemedicine.Web.Controllers
{
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