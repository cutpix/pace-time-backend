using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PaceTime.WebAPI.Data
{
    public class FitnessInitializer : MigrateDatabaseToLatestVersion<FitnessContext, FitnessConfiguration>
    {
        public override void InitializeDatabase(FitnessContext context)
        {
            base.InitializeDatabase(context);
        }
    }

    public class SecurityInitializer : MigrateDatabaseToLatestVersion<SecurityContext, SecurityConfiguration>
    {
        public override void InitializeDatabase(SecurityContext context)
        {
            base.InitializeDatabase(context);
        }
    }
}