﻿namespace PersonalFinanceManagementProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions => Set<Transaction>();

        public DbSet<Budget> Budgets => Set<Budget>();

        public DbSet<User> Users => Set<User>();

        public DbSet<Account> Accounts => Set<Account>();

        
    }
}
