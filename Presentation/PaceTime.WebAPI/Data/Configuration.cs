using Microsoft.AspNet.Identity.EntityFramework;
using PaceTime.Domain.Models;
using PaceTime.WebAPI.Managers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace PaceTime.WebAPI.Data
{
    public class Configuration : DbMigrationsConfiguration<BooksContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(BooksContext context)
        {
            context.Books.AddOrUpdate(new Book
            {
                Id = Guid.NewGuid(),
                Title = "Millionnaire Fastlane",
                Description = "Is the financial plan of mediocrity -- a dream-stealing, soul-sucking dogma known as \"The Slowlane\" your plan for creating wealth? You know how it goes; it sounds a little something like this: \"Go to school, get a good job, save 10 % of your paycheck, buy a used car, cancel the movie channels, quit drinking expensive Starbucks lattes, save and penny - pinch your life away, trust your life - savings to the stock market, and one day, when you are oh, say, 65 years old, you can retire rich.\"",
                Price = 14.51m,
                ImageUrl = "http://ecx.images-amazon.com/images/I/514kBeGrXDL._SX331_BO1,204,203,200_.jpg"
            });

            context.Books.AddOrUpdate(new Book
            {
                Id = Guid.NewGuid(),
                Title = "The Martian",
                Description = "I’m stranded on Mars.  I have no way to communicate with Earth.  I’m in a Habitat designed to last 31 days.",
                Price = 4m,
                ImageUrl = "http://ecx.images-amazon.com/images/I/51xjFVB0AkL._SX312_BO1,204,203,200_.jpg"
            });

            context.Books.AddOrUpdate(new Book
            {
                Id = Guid.NewGuid(),
                Title = "Richest Man in Babylon",
                Description = "This timeless book holds that the key to success lies in the secrets of the ancients. Based on the famous \"Babylonian principles,\" it's been hailed as the greatest of all inspirational works on the subject of thrift and financial planning.",
                Price = 0.99m,
                ImageUrl = "http://ecx.images-amazon.com/images/I/41JGlyCt5NL._SX326_BO1,204,203,200_.jpg"
            });

            context.Books.AddOrUpdate(new Book
            {
                Id = Guid.NewGuid(),
                Title = "100 Property Investment Tips",
                Description = "Rob Dix and Rob Bence are the founders of The Property Hub community, and hosts of The Property Podcast - the UK’s most popular business podcast. They’ve compiled advice from 30 experts and added their own insights to cover a huge range of property-related topics.",
                Price = 3.58m,
                ImageUrl = "http://ecx.images-amazon.com/images/I/41hi2zpZ1uL._SX311_BO1,204,203,200_.jpg"
            });

            context.Books.AddOrUpdate(new Book
            {
                Id = Guid.NewGuid(),
                Title = "Why Does E=mc2?",
                Description = "The most accessible, entertaining, and enlightening explanation of the best-known physics equation in the world, as rendered by two of today’s leading scientists.",
                Price = 5.98m,
                ImageUrl = "http://ecx.images-amazon.com/images/I/3148zK20NuL._SX327_BO1,204,203,200_.jpg"
            });

            context.Books.AddOrUpdate(new Book
            {
                Id = Guid.NewGuid(),
                Title = "A Beautiful Mind",
                Description = "A Beautiful Mind is Sylvia Nasar's award-winning biography about the mystery of the human mind, the triumph over incredible adversity, and the healing power of love.",
                Price = 6.99m,
                ImageUrl = "http://ecx.images-amazon.com/images/I/41pmjXYdOHL._SX309_BO1,204,203,200_.jpg"
            });


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
                var administrator = context.Users.Add(new IdentityUser("administrator") { Email = "admin@somesite.com", EmailConfirmed = true });
                administrator.Roles.Add(new IdentityUserRole { RoleId = adminRoleId });

                var standardUser = context.Users.Add(new IdentityUser("jonpreece") { Email = "jon@somesite.com", EmailConfirmed = true });
                standardUser.Roles.Add(new IdentityUserRole { RoleId = userRoleId });

                context.SaveChanges();

                var store = new BookUserStore();
                store.SetPasswordHashAsync(administrator, new BookUserManager().PasswordHasher.HashPassword("admin123"));
                store.SetPasswordHashAsync(standardUser, new BookUserManager().PasswordHasher.HashPassword("user123"));
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}