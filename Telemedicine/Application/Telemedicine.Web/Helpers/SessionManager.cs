using System.Web;
using Telemedicine.Business.Interfaces.CommonDto;

namespace Telemedicine.Web.Helpers
{
    public static class SessionManager
    {
        private const string CURRENT_USER_ID = "UserId";

        /// <summary>
        /// Current user ID
        /// </summary>
        public static int UserId
        {
            get { return (int)HttpContext.Current.Session[CURRENT_USER_ID]; }
            set { HttpContext.Current.Session[CURRENT_USER_ID] = value; }
        }

        public static void InitSession(DoctorDto user)
        {
           // UserId = user.Id;
        }
    }
}