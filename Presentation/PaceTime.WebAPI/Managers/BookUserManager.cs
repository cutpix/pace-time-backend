using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PaceTime.WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaceTime.WebAPI.Managers
{
    public class BookUserManager : UserManager<IdentityUser>
    {
        public BookUserManager()
            : base(new BookUserStore())
        {
        }
    }
}