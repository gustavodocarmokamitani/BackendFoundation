using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("StatusAgendamento")]
    public class StatusAgendamento
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}
