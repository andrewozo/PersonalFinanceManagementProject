namespace PersonalFinanceManagementProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions => Set<Transaction>();

        public DbSet<Budget> Budgets => Set<Budget>();

        
    }
}
