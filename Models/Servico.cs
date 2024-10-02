using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    [Table("Servico")]
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int DuracaoMinutos { get; set; }  // Duração em minutos
        public float Preco { get; set; }  // Preço do serviço
        public int CabeleireiroId { get; set; }  // FK para Cabeleireiro

        // Relacionamentos
        [JsonIgnore]
        public Cabeleireiro? Cabeleireiro { get; set; }
        [JsonIgnore]
        public ICollection<Agendamento>? Agendamentos { get; set; }
    }
}
