using Microsoft.AspNet.Identity.EntityFramework;


namespace PaceTime.WebAPI.Data
{
    public class SecurityUserStore : UserStore<IdentityUser>
    {
        public SecurityUserStore()
            : base(new SecurityContext())
        {
        }
    }
}