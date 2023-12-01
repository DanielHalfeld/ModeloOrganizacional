using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModeloOrganizacional.Models;

namespace ModeloOrganizacional.Data
{
    public class ContasContext : IdentityDbContext<ApplicationUser>
    {
        public ContasContext(DbContextOptions<ContasContext> options) : base(options) { }
    }
}
