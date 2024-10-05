using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    [Table("Servico")]
    public class Servico
    {
        public int Id { get; set; }
        public int TipoServicoId { get; set; } // FK para Funcionario

        // Relacionamentos
        [JsonIgnore]
        public TipoServico? TipoServico { get; set; }

        [JsonIgnore]
        public Funcionario? Funcionario { get; set; }
        
        [JsonIgnore]
        public ICollection<Agendamento>? Agendamentos { get; set; }
    }
}
