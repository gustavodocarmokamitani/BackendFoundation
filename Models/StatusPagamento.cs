using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("StatusPagamento")]
    public class StatusPagamento
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

    }
}
