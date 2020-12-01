using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpartaProjectWebApp.Models;

namespace SpartaProjectWebApp.Data
{
    public class SpartaProjectWebAppContext : DbContext
    {
        public SpartaProjectWebAppContext (DbContextOptions<SpartaProjectWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<SpartaProjectWebApp.Models.Product> Product { get; set; }

        public DbSet<SpartaProjectWebApp.Models.Review> Review { get; set; }
    }
}
