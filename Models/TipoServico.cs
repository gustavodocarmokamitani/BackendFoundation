using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("TipoServico")]
    public class TipoServico
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int Valor { get; set; }
        public bool Ativo { get; set; }
        public int DuracaoMinutos { get; set; }
    }
}
