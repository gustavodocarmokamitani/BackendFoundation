using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public bool Confirmado { get; set; }

        public string DescricaoPresente { get; set; }

    }
}
