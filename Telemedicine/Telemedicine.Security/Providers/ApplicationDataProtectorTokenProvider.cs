using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;

namespace Telemedicine.Security.Providers
{
    public class ApplicationDataProtectorTokenProvider<TUser> : DataProtectorTokenProvider<TUser, int>
        where TUser : class, IUser<int>
    {
        public ApplicationDataProtectorTokenProvider(IDataProtector protector) : base(protector)
        {
        }
    }
}
