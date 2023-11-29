using ModeloOrganizacional.Models;
using Microsoft.EntityFrameworkCore;

namespace ModeloOrganizacional.Data
{
    public class ModeloOrganizacionalContext : DbContext
    {
        public ModeloOrganizacionalContext(DbContextOptions<ModeloOrganizacionalContext> options) : base(options) { }
        public DbSet<Usuarios> Usuarios { get; set; }

    }
}
