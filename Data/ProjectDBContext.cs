using Microsoft.EntityFrameworkCore;
using ProjetDotNet.Models.DBModels;

namespace ProjetDotNet.Data
{
    public class ProjectDBContext : DbContext
    {
        public ProjectDBContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Users> Users { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Option> Options { get; set; }

    }
}
