using LOANAPI.Entites;
using Microsoft.EntityFrameworkCore;
namespace LoanAPI.Entites
{
    public class LoanDbContext : DbContext
    {
        //public UworldDBContext(DbContextOptions<UworldDBContext> options):base(options)
        //{

        //}
        //Entity sets
        public DbSet<EmployeeMastersEntity> EMEntity { get; set; }
        public DbSet<Entities.EmployeeCardDetailsEntity> ECDEntity { get; set; }
        public DbSet<EmployeeIssueDetailsEntity> EIDEntity { get; set; }
        public DbSet<Entity.ItemMasterEntity> IMEntity { get; set; }
        public DbSet<Entities.LoanCardMasterEntity> LCMEntity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=WINDOWS-BVQNF6J;database=LoanDb;trusted_connection=true;encrypt=false");
        }
    }
}