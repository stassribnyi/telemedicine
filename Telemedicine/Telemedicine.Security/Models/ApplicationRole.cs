using Microsoft.AspNet.Identity.EntityFramework;

namespace Telemedicine.Security.Models
{
    public class ApplicationRole : IdentityRole<int, ApplicationUserRole>
    {
    }
}
