using EncurtadorLinks.Models;
using EncurtadorLinks.Services;
using Microsoft.EntityFrameworkCore;

namespace LinksEncurtador.Core.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<RequisicaoURL> URLsEncurtadas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequisicaoURL>(builder =>
            {
                builder.HasKey(s => s.Id);

                builder.Property(s => s.Code).HasMaxLength(URLShortening.MAX_CHARS_BY_URL);
                builder.HasIndex(s => s.Code).IsUnique();
            });
        }
    }
}
