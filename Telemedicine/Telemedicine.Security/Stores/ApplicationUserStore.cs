using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Threading.Tasks;
using Telemedicine.Security.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using Telemedicine.Security.Common;
using Telemedicine.Common.Factories;
using AutoMapper;

namespace Telemedicine.Security.Stores
{
    public class ApplicationUserStore : IUserStore<ApplicationUser, int>,
                         IUserClaimStore<ApplicationUser, int>,
                         IUserLoginStore<ApplicationUser, int>,
                         IUserRoleStore<ApplicationUser, int>,
                         IUserPasswordStore<ApplicationUser, int>,
                         IUserSecurityStampStore<ApplicationUser, int>,
                         IUserEmailStore<ApplicationUser, int>,
                         IUserLockoutStore<ApplicationUser, int>,
                         IUserTwoFactorStore<ApplicationUser, int>
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

        public async Task CreateAsync(ApplicationUser user)
        {
            Hospital hospital = null;
            if (user.Hospital != null)
            {
                hospital = _db.Hospitals.Find(user.Hospital.Id);
                user.Hospital = null;
            }
            user.Hospital = hospital;
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(ApplicationUser user)
        {
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
        }

        public async Task<ApplicationUser> FindByIdAsync(int userId)
        {
            return await _db.Users.SingleOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<ApplicationUser> FindByNameAsync(string userName)
        {
            return await _db.Users.SingleOrDefaultAsync(x => x.UserName.ToLower().Equals(userName.ToLower()));
        }

        public async Task UpdateAsync(ApplicationUser user)
        {
            _db.Users.Attach(user);
            _db.Entry(user).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task AddLoginAsync(ApplicationUser user, UserLoginInfo login)
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

            await _db.SaveChangesAsync();
        }

        public async Task RemoveLoginAsync(ApplicationUser user, UserLoginInfo login)
        {
            var userLogin = user.Logins.SingleOrDefault(x => x.ProviderKey.Equals(login.ProviderKey) && x.LoginProvider.Equals(login.LoginProvider));
            if (userLogin != null)
            {
                user.Logins.Remove(userLogin);
            }

            await _db.SaveChangesAsync();
        }

        public async Task<IList<UserLoginInfo>> GetLoginsAsync(ApplicationUser user)
        {
            return await Task.FromResult(user.Logins.Select(x => new UserLoginInfo(x.LoginProvider, x.ProviderKey)).ToList());
        }

        public async Task<ApplicationUser> FindAsync(UserLoginInfo login)
        {
            return await _db.Users.SingleOrDefaultAsync(x => x.Logins.Any(z => z.ProviderKey.Equals(login.ProviderKey) && z.LoginProvider.Equals(login.LoginProvider)));
        }

        public async Task<IList<Claim>> GetClaimsAsync(ApplicationUser user)
        {
            return await Task.FromResult(user.Claims.Select(x => new Claim(x.ClaimType, x.ClaimValue)).ToList());
        }

        //TODO Test this solution
        public async Task AddClaimAsync(ApplicationUser user, Claim claim)
        {
            var entity = await _db.Users.SingleOrDefaultAsync(x => x.Id == user.Id);
            if (entity == null) throw new ObjectNotFoundException();
            entity.Claims.Add(new ApplicationUserClaim
            {
                ClaimType = claim.Type,
                ClaimValue = claim.Value
            });

            await _db.SaveChangesAsync();
        }

        public Task RemoveClaimAsync(ApplicationUser user, Claim claim)
        {
            throw new NotImplementedException();
        }

        public async Task AddToRoleAsync(ApplicationUser user, string roleName)
        {
            var entity = await _db.Users.SingleOrDefaultAsync(x => x.Id == user.Id);
            var role = await _db.Roles.SingleOrDefaultAsync(x => x.Name.Equals(roleName));
            if (entity == null) throw new ObjectNotFoundException();
            if (role == null) throw new ObjectNotFoundException();
            entity.Roles.Add(new ApplicationUserRole
            {
                RoleId = role.Id,
                UserId = user.Id
            });

            await _db.SaveChangesAsync();
        }

        public async Task RemoveFromRoleAsync(ApplicationUser user, string roleName)
        {
            var role = _db.Roles.SingleOrDefault(x => x.Name.Equals(roleName));

            if (role == null)
            {
                throw new ObjectNotFoundException();
            }

            var userRole = user.Roles.SingleOrDefault(x => x.RoleId == role.Id);

            if (userRole != null)
            {
                user.Roles.Remove(userRole);
            }

            await _db.SaveChangesAsync();
        }

        public async Task<IList<string>> GetRolesAsync(ApplicationUser user)
        {
            var roles = _db.Roles;
            var elements = new List<ApplicationRole>();

            foreach (var role in roles)
            {
                if (user.Roles.Any(x => x.RoleId == role.Id))
                {
                    elements.Add(role);
                }
            }

            var result = elements.Select(x => x.Name).ToList();
            return await Task.FromResult(result);
        }

        public async Task<bool> IsInRoleAsync(ApplicationUser user, string roleName)
        {
            var roles = _db.Roles;
            var elements = new List<ApplicationRole>();

            foreach (var role in roles)
            {
                if (user.Roles.Any(x => x.RoleId == role.Id))
                {
                    elements.Add(role);
                }
            }

            var isInRole = elements.Any(x => x.Name.Equals(roleName));
            return await Task.FromResult(isInRole);
        }

        public async Task SetSecurityStampAsync(ApplicationUser user, string stamp)
        {
            user.SecurityStamp = stamp;
            await Task.FromResult(0);
        }

        public async Task<string> GetSecurityStampAsync(ApplicationUser user)
        {
            return await Task.FromResult(user.SecurityStamp);
        }

        public async Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            await Task.FromResult(0);
        }

        public async Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            return await Task.FromResult(user.PasswordHash);
        }

        public async Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            var hasPassword = string.IsNullOrEmpty(user.PasswordHash);
            return await Task.FromResult(hasPassword);
        }

        public async Task SetEmailAsync(ApplicationUser user, string email)
        {
            user.Email = email;
            await Task.FromResult(0);
        }

        public async Task<string> GetEmailAsync(ApplicationUser user)
        {
            return await Task.FromResult(user.Email);
        }

        public async Task<bool> GetEmailConfirmedAsync(ApplicationUser user)
        {
            return await Task.FromResult(user.EmailConfirmed);
        }

        public async Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed)
        {
            user.EmailConfirmed = confirmed;
            await Task.FromResult(0);
        }

        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return await _db.Users.SingleOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));
        }

        private ApplicationUser ToIdentityUser(ApplicationUser user)
        {
            return new ApplicationUser
            {
                Id = user.Id,
                PasswordHash = user.PasswordHash,
                SecurityStamp = user.SecurityStamp,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
        }

        public async Task<DateTimeOffset> GetLockoutEndDateAsync(ApplicationUser user)
        {
            var lockOutDate = user.LockoutEndDateUtc.HasValue ? user.LockoutEndDateUtc.Value : new DateTimeOffset(DateTime.Now.AddMinutes(-5));
            return await Task.FromResult(lockOutDate);
        }

        public async Task SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset lockoutEnd)
        {
            user.LockoutEndDateUtc = DateTime.UtcNow.AddMinutes(lockoutEnd.Minute);
            user.LockoutEnabled = true;
            await _db.SaveChangesAsync();
        }

        public async Task<int> IncrementAccessFailedCountAsync(ApplicationUser user)
        {
            user.AccessFailedCount++;
            return await _db.SaveChangesAsync();
        }

        public async Task ResetAccessFailedCountAsync(ApplicationUser user)
        {
            user.AccessFailedCount = 0;
            await _db.SaveChangesAsync();
        }

        public async Task<int> GetAccessFailedCountAsync(ApplicationUser user)
        {
            return await Task.FromResult(user.AccessFailedCount);
        }

        public async Task<bool> GetLockoutEnabledAsync(ApplicationUser user)
        {
            return await Task.FromResult(user.LockoutEnabled);
        }

        public async Task SetLockoutEnabledAsync(ApplicationUser user, bool enabled)
        {
            user.LockoutEnabled = enabled;
            await _db.SaveChangesAsync();
        }

        public async Task SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled)
        {
            user.TwoFactorEnabled = enabled;
            await _db.SaveChangesAsync();
        }

        public async Task<bool> GetTwoFactorEnabledAsync(ApplicationUser user)
        {
            return await Task.FromResult(user.TwoFactorEnabled);
        }
    }
}
