using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    [Table("Pagamento")]
    public class Pagamento
    {
        public int Id { get; set; }
        public int AgendamentoId { get; set; } // FK para Agendamento
        public int? MetodoPagamentoId { get; set; }  // 1 Credito 2 Debito 3 Dinheiro 4 Pix 5 Outros
        public int? StatusPagamentoId { get; set; } // 1 Confirmado 2 Pendente
        public float? ValorPago { get; set; }

        // Relacionamento
        [JsonIgnore]
        public Agendamento? Agendamento { get; set; }
        [JsonIgnore]
        public StatusPagamento? StatusPagamento { get; set; }
        [JsonIgnore]
        public MetodoPagamento? MetodoPagamento { get; set; }
    }
}
