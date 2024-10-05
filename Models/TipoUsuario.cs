using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("TipoUsuario")]
    public class TipoUsuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}
