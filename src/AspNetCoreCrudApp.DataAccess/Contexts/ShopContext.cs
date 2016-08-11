using Microsoft.EntityFrameworkCore;
using AspNetCoreCrudApp.DataAccess.Entities;
using AspNetCoreCrudApp.DataAccess.Interfaces;
using Microsoft.DotNet.InternalAbstractions;

namespace AspNetCoreCrudApp.DataAccess.Contexts
{
    public class ShopContext : DbContext, IShopContext
    {
        /// <summary>
        /// ApplicationEnvironment.ApplicationBasePath returns path to AspNetCoreCrudApp\src\AspNetCoreCrudApp.Web\bin\Debug\netcoreapp1.0;
        /// </summary>
        private static readonly string ConnectionString = @"Data Source=" + ApplicationEnvironment.ApplicationBasePath + @"\Shop.db;";

        public ShopContext() : base()
        {
            Database.EnsureCreated();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConnectionString);
            
            base.OnConfiguring(optionsBuilder);
        }
    }
}
