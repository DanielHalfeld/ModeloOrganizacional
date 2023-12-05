using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModeloOrganizacional.Models;

namespace ModeloOrganizacional.Data
{
    public class ContasContext : IdentityDbContext<ApplicationUser>
    {
        public ContasContext(DbContextOptions<ContasContext> options) : base(options) { }

        public DbSet<Topicos> Topicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Topicos>()
                .HasOne(t => t.ApplicationUser)
                .WithMany(u => u.Topicos)
                .HasForeignKey(t => t.ApplicationUserId);
        }
    }
}
