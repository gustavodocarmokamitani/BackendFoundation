using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    [Table("Servico")]
    public class Servico
    {
        public int Id { get; set; }
        public int TipoServicoId { get; set; } // FK para Cabeleleiro

        // Relacionamentos
        [JsonIgnore]
        public TipoServico? TipoServico { get; set; }

        [JsonIgnore]
        public Cabeleleiro? Cabeleleiro { get; set; }
        
        [JsonIgnore]
        public ICollection<Agendamento>? Agendamentos { get; set; }
    }
}
