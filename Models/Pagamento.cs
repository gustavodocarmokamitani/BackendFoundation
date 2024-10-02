using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    [Table("Pagamento")]
    public class Pagamento
    {
        public int Id { get; set; }
        public int AgendamentoId { get; set; } // FK para Agendamento
        public string MetodoPagamento { get; set; } = string.Empty; // Cartão, Dinheiro
        public string StatusPagamento { get; set; } = string.Empty; // Pago, Pendente
        public float ValorPago { get; set; }

        // Relacionamento
        [JsonIgnore]
        public Agendamento? Agendamento { get; set; }
    }
}
