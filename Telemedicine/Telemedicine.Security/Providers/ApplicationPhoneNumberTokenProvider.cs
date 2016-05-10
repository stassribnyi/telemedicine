using Microsoft.AspNet.Identity;

namespace Telemedicine.Security.Providers
{
    public class ApplicationPhoneNumberTokenProvider<TUser> : PhoneNumberTokenProvider<TUser, int> 
        where TUser : class, IUser<int>
    {
    }
}
