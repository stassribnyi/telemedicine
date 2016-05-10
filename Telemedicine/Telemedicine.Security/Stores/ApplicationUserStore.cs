using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Threading.Tasks;
using Telemedicine.Security.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;

namespace Telemedicine.Security.Stores
{
    public class ApplicationUserStore : IUserStore<ApplicationUser, int>,
                         IUserClaimStore<ApplicationUser, int>,
                         IUserLoginStore<ApplicationUser, int>,
                         IUserRoleStore<ApplicationUser, int>,
                         IUserPasswordStore<ApplicationUser, int>,
                         IUserSecurityStampStore<ApplicationUser, int>
    {
        private IdentityContext _db;

        public ApplicationUserStore()
        {
            _db = new IdentityContext();
        }

        public ApplicationUserStore(IdentityContext database)
        {
            _db = database;
        }

        public Task CreateAsync(ApplicationUser user)
        {
            _db.Users.Add(user);
            return _db.SaveChangesAsync();
        }

        public Task DeleteAsync(ApplicationUser user)
        {
            _db.Users.Remove(user);
            return _db.SaveChangesAsync();
        }

        public Task<ApplicationUser> FindByIdAsync(int userId)
        {
            return _db.Users.SingleOrDefaultAsync(x => x.Id == userId);
        }

        public Task<ApplicationUser> FindByNameAsync(string userName)
        {
            return _db.Users.SingleOrDefaultAsync(x => x.UserName.ToLower().Equals(userName.ToLower()));
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            _db.Users.Attach(user);
            _db.Entry(user).State = EntityState.Modified;
            return _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public Task AddLoginAsync(ApplicationUser user, UserLoginInfo login)
        {
            var result = _db.Users.SingleOrDefault(x => x.Id == user.Id);

            if (result != null)
            {
                result.Logins.Add(new ApplicationUserLogin
                {
                    LoginProvider = login.LoginProvider,
                    ProviderKey = login.ProviderKey,
                    UserId = result.Id
                });
            }

            return _db.SaveChangesAsync();
        }

        public Task RemoveLoginAsync(ApplicationUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(ApplicationUser user)
        {
            throw new NotImplementedException();

            //return _db.Users.SingleOrDefault(x => x.Id == user.Id).Logins.Select(x=>new UserLoginInfo(x.LoginProvider, x.ProviderKey)).ToListAsync();
        }

        public Task<ApplicationUser> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Claim>> GetClaimsAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task AddClaimAsync(ApplicationUser user, Claim claim)
        {
            throw new NotImplementedException();
        }

        public Task RemoveClaimAsync(ApplicationUser user, Claim claim)
        {
            throw new NotImplementedException();
        }

        public Task AddToRoleAsync(ApplicationUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(ApplicationUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(ApplicationUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task SetSecurityStampAsync(ApplicationUser user, string stamp)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetSecurityStampAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
