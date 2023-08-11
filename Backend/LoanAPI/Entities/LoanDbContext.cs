
using LOANAPI.Entites;
using Microsoft.EntityFrameworkCore;
namespace LoanAPI.Entites
{
    public class LoanDbContext : DbContext
    {
        //internal object Admin;
        //internal object AdminEntitys;

        /*public LoanDbContext(DbContextOptions<LoanDbContext> options):base(options)
        {

        }*/
        //Entity sets
        public DbSet<EmployeeMastersEntity> EMEntity { get; set; }
        public DbSet<EmployeeCardDetailsEntity> ECDEntity { get; set; }
        public DbSet<EmployeeIssueDetailsEntity> EIDEntity { get; set; }
        public DbSet<ItemMasterEntity> IMEntity { get; set; }
        public DbSet<LoanCardMasterEntity> LCMEntity { get; set; }
        public DbSet<AdminEntity> AdminEntity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-E6B8VLA\SQLEXPRESS;database=LoanDb;trusted_connection=true");
        }
    }
    

}