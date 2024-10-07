using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    [Table("Servico")]
    public class Servico
    {
        public int Id { get; set; }
        public int TipoServicoId { get; set; }

        // Relacionamentos
        [JsonIgnore]
        public TipoServico? TipoServico { get; set; }

        [JsonIgnore]
        public Funcionario? Funcionario { get; set; }
        
        [JsonIgnore]
        public Agendamento? Agendamentos { get; set; }
    }
}
