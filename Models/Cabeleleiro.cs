using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace backend.Models
{
    [Table("Cabeleleiro")]
    public class Cabeleleiro
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }

        public List<int> ServicosId { get; set; } = new List<int>();

        [JsonIgnore]
        public Usuario? Usuario { get; set; }

        [JsonIgnore]
        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

        [JsonIgnore]
        public ICollection<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
        
        [JsonIgnore]
        public ICollection<Servico> Servicos { get; set; } = new List<Servico>();
    }
}
