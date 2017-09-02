using Microsoft.AspNet.Identity.EntityFramework;
using PaceTime.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PaceTime.WebAPI.Data
{
    public class BooksContext : IdentityDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}