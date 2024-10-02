using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public class SalaoContext : DbContext
    {
        public SalaoContext(DbContextOptions<SalaoContext> options) : base(options) { }

        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
