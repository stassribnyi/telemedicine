using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Telemedicine.Security.Models;

namespace Telemedicine.Security
{
    public class IdentityContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public IdentityContext()
            : base("TelemedicineContext")
        {
        }

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUserRole>()
                .HasKey(r => new { r.UserId, r.RoleId })
                .ToTable("UserRoles");

            modelBuilder.Entity<ApplicationUserLogin>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId })
                .ToTable("UserLogins");

            modelBuilder.Entity<ApplicationRole>()
               .ToTable("Roles");

            modelBuilder.Entity<ApplicationUserClaim>()
              .ToTable("UserClaim");


            modelBuilder.Configurations.Add(new ApplicationUserMap());

        }

        public class ApplicationUserMap : EntityTypeConfiguration<ApplicationUser>
        {
            public ApplicationUserMap()
            {               
                this.ToTable("Doctors");
                this.Property(t => t.Id).HasColumnName("Id");
                this.Property(t => t.Email).HasColumnName("Email");
                this.Property(t => t.UserName).HasColumnName("Login");
                this.Property(t => t.PhoneNumber).HasColumnName("Phone");
                this.Property(t => t.PasswordHash).HasColumnName("Password");
            }
        }

    }
}
