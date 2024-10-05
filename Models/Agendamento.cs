using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    [Table("Agendamento")]
    public class Agendamento
    {
        public int Id { get; set; }
        public int ClienteId { get; set; } // FK para Usuario (Cliente)
        public int FuncionarioId { get; set; } // FK para Funcionario
        public DateTime DataAgendamento { get; set; }
        public int StatusAgendamentoId { get; set; } // 1 Confirmado, 2 Cancelado, 3 Pendente
        public List<Servico> ServicosId { get; set; } = new List<Servico>();

        // Relacionamentos
        [JsonIgnore]
        public Usuario? Cliente { get; set; }

        [JsonIgnore]
        public Funcionario? Funcionario { get; set; }

        [JsonIgnore]
        public Pagamento? Pagamento { get; set; }

        [JsonIgnore]
        public StatusAgendamento? StatusAgendamento { get; set; }
    }
}
