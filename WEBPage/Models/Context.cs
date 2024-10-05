using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WEBPage.Models.Identity;

namespace WEBPage.Models
{
    public class ProjectContext : IdentityDbContext<ApplicationUser>
    {
        //public ProjectContext() : base()
        //{            
        //}
        public ProjectContext(DbContextOptions options) : base(options)
        {            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=FinalProject;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
