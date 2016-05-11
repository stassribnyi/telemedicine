using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Telemedicine.Security.Managers;

namespace Telemedicine.Security.Models
{
    public class ApplicationUser : IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {                
        [MinLength(3)]
        [MaxLength(16)]
        public string FirstName { get; set; }
        [MinLength(3)]
        [MaxLength(16)]
        public string LastName { get; set; }
        [MinLength(3)]
        [MaxLength(16)]
        public string Patronimic { get; set; }
              
        public string MedicalSpecialization { get; set; }

        public bool IsArchive { get; set; }        

        public virtual Hospital Hospital { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
