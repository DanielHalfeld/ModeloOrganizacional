using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ModeloOrganizacional.Models
{
    public class Topicos
    {
        [DisplayName("Código")]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        [Required]
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}