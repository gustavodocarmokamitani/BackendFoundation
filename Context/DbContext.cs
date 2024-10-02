using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class SalaoContext : DbContext
{
    private readonly IConfiguration _configuration;

    // Construtor que aceita DbContextOptions
    public SalaoContext(DbContextOptions<SalaoContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 36)));
        }
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Cabeleireiro> Cabeleireiros { get; set; }
    public DbSet<Servico> Servicos { get; set; }
    public DbSet<Agendamento> Agendamentos { get; set; }
    public DbSet<Pagamento> Pagamentos { get; set; }
    public DbSet<Avaliacao> Avaliacoes { get; set; }

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

        // Configuração para Cabeleireiro
        modelBuilder.Entity<Cabeleireiro>()
            .HasOne(c => c.Usuario)
            .WithMany()
            .HasForeignKey(c => c.UsuarioId);

        modelBuilder.Entity<Cabeleireiro>()
            .HasMany(c => c.Agendamentos)
            .WithOne(a => a.Cabeleireiro)
            .HasForeignKey(a => a.CabeleireiroId);

        modelBuilder.Entity<Cabeleireiro>()
            .HasMany(c => c.Servicos)
            .WithOne(s => s.Cabeleireiro)
            .HasForeignKey(s => s.CabeleireiroId);

        modelBuilder.Entity<Cabeleireiro>()
            .HasMany(c => c.Avaliacoes)
            .WithOne(a => a.Cabeleireiro)
            .HasForeignKey(a => a.CabeleireiroId);

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
            .HasOne(a => a.Cabeleireiro)
            .WithMany(c => c.Avaliacoes)
            .HasForeignKey(a => a.CabeleireiroId);
    }
}
