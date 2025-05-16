using Microsoft.EntityFrameworkCore;
using NFTMVCPROJECT.Models;



namespace NFTMVCPROJECT.Contexts
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString = @"Server=DESKTOP-GTVND9D\SQLEXPRESS;Database=NftMvcProject;Trusted_Connection=True;TrustServerCertificate=True";
        public DbSet<Collection> collections { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
