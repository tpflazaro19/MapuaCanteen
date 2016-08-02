using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MapuaCanteen.Models;

namespace MapuaCanteen.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<StudentAccounts> StudentAccounts { get; set; }

        public DbSet<ChefBabsProducts> ChefBabsProducts { get; set; }

        public DbSet<PajGrillProducts> PajGrillProducts { get; set; }

        public DbSet<PaotsinProducts> PaotsinProducts { get; set; }
    }
}
