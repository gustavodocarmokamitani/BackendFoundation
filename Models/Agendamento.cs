using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    [Table("Agendamento")]
    public class Agendamento
    {
        public int Id { get; set; }
        public int ClienteId { get; set; } // FK para Usuario (Cliente)
        public int CabeleireiroId { get; set; } // FK para Cabeleireiro
        public int ServicoId { get; set; } // FK para Servico
        public DateTime DataAgendamento { get; set; }
        public string? Status { get; set; } // Confirmado, Cancelado, Pendente

        // Relacionamentos
        [JsonIgnore]
        public Usuario? Cliente { get; set; }
        [JsonIgnore]
        public Cabeleireiro? Cabeleireiro { get; set; }
        [JsonIgnore]
        public Servico? Servico { get; set; }
        [JsonIgnore]
        public Pagamento? Pagamento { get; set; }
    }
}
