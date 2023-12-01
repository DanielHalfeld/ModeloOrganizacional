using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace ModeloOrganizacional.Models
{
    public class Topicos
    {
        [DisplayName("Código")]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string UsuarioId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
