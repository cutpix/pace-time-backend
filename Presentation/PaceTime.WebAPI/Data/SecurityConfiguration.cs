using Microsoft.AspNet.Identity.EntityFramework;
using PaceTime.WebAPI.Managers;
using System.Data.Entity.Migrations;
using System.Linq;

namespace PaceTime.WebAPI.Data
{
    public class SecurityConfiguration : DbMigrationsConfiguration<SecurityContext>
    {
        public SecurityConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(SecurityContext context)
        {
            // Seeding users to database
            string adminRoleId, userRoleId;
            if (!context.Roles.Any())
            {
                adminRoleId = context.Roles.Add(new IdentityRole("Administrator")).Id;
                userRoleId = context.Roles.Add(new IdentityRole("User")).Id;
            }
            else
            {
                adminRoleId = context.Roles.First(c => c.Name == "Administrator").Id;
                userRoleId = context.Roles.First(c => c.Name == "User").Id;
            }

            context.SaveChanges();

            if (!context.Users.Any())
            {
                var administrator = context.Users.Add(new IdentityUser("admin") { Email = "admin@somesite.com", EmailConfirmed = true });
                administrator.Roles.Add(new IdentityUserRole { RoleId = adminRoleId });

                var standardUser = context.Users.Add(new IdentityUser("jonpreece") { Email = "jon@somesite.com", EmailConfirmed = true });
                standardUser.Roles.Add(new IdentityUserRole { RoleId = userRoleId });

                context.SaveChanges();

                var store = new SecurityUserStore();
                store.SetPasswordHashAsync(administrator, new SecurityUserManager().PasswordHasher.HashPassword("admin123"));
                store.SetPasswordHashAsync(standardUser, new SecurityUserManager().PasswordHasher.HashPassword("user123"));
            }

            base.Seed(context);
        }
    }
}