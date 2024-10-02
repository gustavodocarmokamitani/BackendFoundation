using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    [Table("Cabeleleiro")]
    public class Cabeleireiro
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; } // FK para Usuario
        public string Especialidade { get; set; } = string.Empty;
        public int AnosExperiencia { get; set; }
        public float AvaliacaoMedia { get; set; }

        // Relacionamentos
        [JsonIgnore]
        public Usuario? Usuario { get; set; }
        [JsonIgnore]
        public ICollection<Agendamento>? Agendamentos { get; set; }
        [JsonIgnore]
        public ICollection<Servico>? Servicos { get; set; }
        [JsonIgnore]
        public ICollection<Avaliacao>? Avaliacoes { get; set; }
    }
}
