using Microsoft.AspNetCore.Identity;

namespace ModeloOrganizacional.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Topicos = new List<Topicos>();
        }

        public virtual ICollection<Topicos> Topicos { get; set; }

    }

}
