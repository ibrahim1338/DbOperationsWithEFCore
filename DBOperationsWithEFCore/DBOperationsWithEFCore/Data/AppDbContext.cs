using DBOperationsWithEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace DBOperationsWithEFCore.Data
{
    public class AppDbContext : DbContext
    {

     public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency() {Id=1, Title="PKR",Description="Pakistani Rupee" },
                new Currency() {Id=2, Title="USD",Description="US Dollar" },
                new Currency() {Id=3, Title="INR",Description="Indian Rupee" },
                new Currency() {Id=4, Title="Euro",Description="European Currency" }
                );
            modelBuilder.Entity<Language>().HasData(
                new Language() {Id=1, Title="English",Description="British English" },
                new Language() {Id=2, Title="Urdu",Description="Urdu" },
                new Language() {Id=3, Title="Hindi",Description="Hindi" },
                new Language() {Id=4, Title="Punjabi",Description="Punjabi" }
                );
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<BookPrice> BookPrices { get; set; }
        
    }
}
