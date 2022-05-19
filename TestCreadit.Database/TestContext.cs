using TestCreadit.Database.TestObjects;
using Microsoft.EntityFrameworkCore;

namespace TestCreadit.Database
{
    public class TestContext : DbContext
    {
        
        public virtual DbSet<Debtor> Debtors { get; set; }
        public virtual DbSet<RequestCredit> RequestsCredit { get; set; }
        public virtual DbSet<DebtorPlaceWork> DebtorPlacesWork { get; set; }
        public virtual DbSet<AdditionalRequestCredit> AdditionalRequestsCredit { get; set; }

        
        public TestContext(DbContextOptions<TestContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}