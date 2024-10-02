using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    [Table("Avaliacao")]
    public class Avaliacao
    {
        public int Id { get; set; }
        public int ClienteId { get; set; } // FK para Usuario (Cliente)
        public int CabeleireiroId { get; set; } // FK para Cabeleireiro
        public int Nota { get; set; }  // Nota de 1-5
        public string Comentario { get; set; } = string.Empty;
        public DateTime DataAvaliacao { get; set; }

        // Relacionamentos
        [JsonIgnore]
        public Usuario? Cliente { get; set; }
        [JsonIgnore]
        public Cabeleireiro? Cabeleireiro { get; set; }
    }
}
