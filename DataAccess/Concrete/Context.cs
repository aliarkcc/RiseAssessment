using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=MEHMETPC\\SQLEXPRESS;database=RiseConsultingWork;integrated security=true");
        }
        public DbSet<ContactInfo> ContactInfos{ get; set; }
        public DbSet<Directory> Directories{ get; set; }
    }
}
