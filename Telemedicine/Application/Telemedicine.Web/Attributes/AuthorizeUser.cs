using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Telemedicine.Web.Helpers;

namespace Telemedicine.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AuthorizeUser : AuthorizeAttribute
    {
        public AuthorizeUser(string[] roles)
        {
            Roles = string.Join(",", roles);
        }

        public AuthorizeUser()
        {

        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var cookie = httpContext.Request.Cookies["doctor"];
            //if (cookie != null)
            //{
            return true;
            //}
            //    else
            //    {
            //        httpContext.Response.StatusCode = 401;
            //        return false;
            //    }
        }
    }
}