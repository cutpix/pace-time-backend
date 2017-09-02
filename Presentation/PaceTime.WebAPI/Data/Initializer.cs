using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PaceTime.WebAPI.Data
{
    public class Initializer : MigrateDatabaseToLatestVersion<BooksContext, Configuration>
    {
    }
}