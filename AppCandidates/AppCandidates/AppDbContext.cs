using AppCandidates.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCandidates
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Candidate> Candidates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>()
                .HasIndex(c => c.Email)
                .IsUnique();
        }

    }
}
