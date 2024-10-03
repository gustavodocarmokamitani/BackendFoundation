using backend.Models;
using Microsoft.EntityFrameworkCore;

public class SalaoContext : DbContext
{
    // Construtor que aceita DbContextOptions e IConfiguration
    public SalaoContext(DbContextOptions<SalaoContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Cabeleleiro> Cabeleleiros { get; set; }
    public DbSet<Servico> Servicos { get; set; }
    public DbSet<Agendamento> Agendamentos { get; set; }
    public DbSet<Pagamento> Pagamentos { get; set; }
    public DbSet<Avaliacao> Avaliacoes { get; set; }
    public DbSet<TipoServico> TipoServicos { get; set; }
    public DbSet<TipoUsuario> TipoUsuarios { get; set; }
    public DbSet<StatusAgendamento> StatusAgendamentos { get; set; }
    public DbSet<StatusPagamento> StatusPagamentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração para Usuario
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Agendamentos)
            .WithOne(a => a.Cliente)
            .HasForeignKey(a => a.ClienteId);

        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Avaliacoes)
            .WithOne(a => a.Cliente)
            .HasForeignKey(a => a.ClienteId);

        // Configuração para Cabeleleiro
        modelBuilder.Entity<Cabeleleiro>()
            .HasOne(c => c.Usuario)
            .WithMany()
            .HasForeignKey(c => c.UsuarioId);

        modelBuilder.Entity<Cabeleleiro>()
            .HasMany(c => c.Agendamentos)
            .WithOne(a => a.Cabeleleiro)
            .HasForeignKey(a => a.CabeleleiroId);

        modelBuilder.Entity<Cabeleleiro>()
            .HasMany(c => c.Servicos)
            .WithOne(s => s.Cabeleleiro)
            .HasForeignKey(s => s.CabeleleiroId);

        modelBuilder.Entity<Cabeleleiro>()
            .HasMany(c => c.Avaliacoes)
            .WithOne(a => a.Cabeleleiro)
            .HasForeignKey(a => a.CabeleleiroId);

        // Configuração para Servico
        modelBuilder.Entity<Servico>()
            .HasMany(s => s.Agendamentos)
            .WithOne(a => a.Servico)
            .HasForeignKey(a => a.ServicoId);

        // Configuração para Agendamento
        modelBuilder.Entity<Agendamento>()
            .HasOne(a => a.Pagamento)
            .WithOne(p => p.Agendamento)
            .HasForeignKey<Pagamento>(p => p.AgendamentoId);

        // Configuração para Avaliacao
        modelBuilder.Entity<Avaliacao>()
            .HasOne(a => a.Cliente)
            .WithMany(u => u.Avaliacoes)
            .HasForeignKey(a => a.ClienteId);

        modelBuilder.Entity<Avaliacao>()
            .HasOne(a => a.Cabeleleiro)
            .WithMany(c => c.Avaliacoes)
            .HasForeignKey(a => a.CabeleleiroId);
    }
}
