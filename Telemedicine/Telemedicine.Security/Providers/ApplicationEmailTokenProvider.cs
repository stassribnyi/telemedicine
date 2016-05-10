using Microsoft.AspNet.Identity;
namespace Telemedicine.Security.Providers
{
    public class ApplicationEmailTokenProvider<TUser> : EmailTokenProvider<TUser, int> 
        where TUser : class, IUser<int>
    {
    }
}
