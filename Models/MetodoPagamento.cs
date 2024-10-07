using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("MetodoPagamento")]
    public class MetodoPagamento
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}
