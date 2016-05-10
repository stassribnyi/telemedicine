using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Telemedicine.Web.Startup))]
namespace Telemedicine.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
