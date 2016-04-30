using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using Telemedicine.Business.Interfaces.Services.DoctorService;
using Telemedicine.Web.Helpers;

namespace Telemedicine.Web.Controllers.Api
{
    public class AccountController : ApiController
    {
        private IDoctorService _doctorService;

        public AccountController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpPost]
        public HttpResponseMessage LogIn([FromBody]Credentials credentials)
        {
            var login = "";
            CookieHeaderValue cookie = Request.Headers.GetCookies("doctor").FirstOrDefault();            

            var authorize = false;

            if (!string.IsNullOrEmpty(credentials.Login) && !string.IsNullOrEmpty(credentials.Password))
                authorize = true;//userService.CheckCredentials(login, token);
            else if (cookie != null)
            {
                CookieState cookieState = cookie["doctor"];
                login = cookieState["login"];
                credentials.Login = login;
                authorize = !string.IsNullOrEmpty(credentials.Login);
            }

            if (!authorize) return Request.CreateResponse(HttpStatusCode.BadRequest);

            var user = _doctorService.GetDoctorByLogin(credentials.Login);
            
            var vals = new NameValueCollection();
            vals["login"] = user.Login;
            vals["id"] = user.Id.ToString();

            var newCookie = new CookieHeaderValue("doctor", vals);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Headers.AddCookies(new CookieHeaderValue[] { newCookie });
            return response;

        }
    }
}
