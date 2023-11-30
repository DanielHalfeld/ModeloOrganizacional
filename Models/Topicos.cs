using System.ComponentModel;

namespace ModeloOrganizacional.Models
{
    public class Topicos
    {
        [DisplayName("Código")]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

    }
}
