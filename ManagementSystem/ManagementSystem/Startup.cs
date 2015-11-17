using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManagementSystem.Startup))]
namespace ManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
