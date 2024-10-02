using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string TipoUsuario { get; set; } = string.Empty;

        // Relacionamentos
        [JsonIgnore]
        public ICollection<Agendamento>? Agendamentos { get; set; }
        [JsonIgnore]
        public ICollection<Avaliacao>? Avaliacoes { get; set; }
    }
}
