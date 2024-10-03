using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    [Table("Agendamento")]
    public class Agendamento
    {
        public int Id { get; set; }
        public int ClienteId { get; set; } // FK para Usuario (Cliente)
        public int CabeleleiroId { get; set; } // FK para Cabeleleiro
        public int ServicoId { get; set; } // FK para Servico
        public DateTime DataAgendamento { get; set; }
        public int StatusAgendamentoId { get; set; } // 1 Confirmado, 2 Cancelado, 3 Pendente

        // Relacionamentos
        [JsonIgnore]
        public Usuario? Cliente { get; set; }
        
        [JsonIgnore]
        public Cabeleleiro? Cabeleleiro { get; set; }
        
        [JsonIgnore]
        public Servico? Servico { get; set; }
       
        [JsonIgnore]
        public Pagamento? Pagamento { get; set; }
        
        [JsonIgnore]
        public StatusAgendamento? StatusAgendamento { get; set; }

        [JsonIgnore]
        public ICollection<Servico> Servicos { get; set; } = new List<Servico>();
    }
}
