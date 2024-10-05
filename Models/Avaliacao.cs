using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    [Table("Avaliacao")]
    public class Avaliacao
    {
        public int Id { get; set; }
        public int ClienteId { get; set; } // FK para Usuario (Cliente)
        public int FuncionarioId { get; set; } // FK para Funcionario
        public int Nota { get; set; }  // Nota de 1-5
        public string Comentario { get; set; } = string.Empty;
        public DateTime DataAvaliacao { get; set; }

        // Relacionamentos
        [JsonIgnore]
        public Usuario? Clientes { get; set; }
        [JsonIgnore]
        public Funcionario? Funcionarios { get; set; }
    }
}
