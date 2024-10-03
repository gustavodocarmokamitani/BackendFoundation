﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(SalaoContext))]
    partial class SalaoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("backend.Models.Agendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CabeleleiroId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAgendamento")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ServicoId")
                        .HasColumnType("int");

                    b.Property<int>("StatusAgendamentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CabeleleiroId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ServicoId");

                    b.HasIndex("StatusAgendamentoId");

                    b.ToTable("Agendamento");
                });

            modelBuilder.Entity("backend.Models.Avaliacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CabeleleiroId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataAvaliacao")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CabeleleiroId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Avaliacao");
                });

            modelBuilder.Entity("backend.Models.Cabeleleiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Cabeleleiro");
                });

            modelBuilder.Entity("backend.Models.CabeleleiroEspecialidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CabeleleiroId")
                        .HasColumnType("int");

                    b.Property<int>("ServicoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CabeleleiroId");

                    b.HasIndex("ServicoId");

                    b.ToTable("CabeleleiroEspecialidade");
                });

            modelBuilder.Entity("backend.Models.MetodoPagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("MetodoPagamento");
                });

            modelBuilder.Entity("backend.Models.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgendamentoId")
                        .HasColumnType("int");

                    b.Property<int?>("MetodoPagamentoId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusPagamentoId")
                        .HasColumnType("int");

                    b.Property<float?>("ValorPago")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AgendamentoId")
                        .IsUnique();

                    b.HasIndex("MetodoPagamentoId");

                    b.HasIndex("StatusPagamentoId");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("backend.Models.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AgendamentoId")
                        .HasColumnType("int");

                    b.Property<int>("CabeleleiroId")
                        .HasColumnType("int");

                    b.Property<int>("TipoServicoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgendamentoId");

                    b.HasIndex("CabeleleiroId");

                    b.HasIndex("TipoServicoId");

                    b.ToTable("Servico");
                });

            modelBuilder.Entity("backend.Models.StatusAgendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("StatusAgendamento");
                });

            modelBuilder.Entity("backend.Models.StatusPagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("StatusPagamento");
                });

            modelBuilder.Entity("backend.Models.TipoServico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("DuracaoMinutos")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TipoServico");
                });

            modelBuilder.Entity("backend.Models.TipoUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("TipoUsuario");
                });

            modelBuilder.Entity("backend.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext");

                    b.Property<int?>("TipoUsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("backend.Models.Agendamento", b =>
                {
                    b.HasOne("backend.Models.Cabeleleiro", "Cabeleleiro")
                        .WithMany("Agendamentos")
                        .HasForeignKey("CabeleleiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.Usuario", "Cliente")
                        .WithMany("Agendamentos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.Servico", "Servico")
                        .WithMany("Agendamentos")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.StatusAgendamento", "StatusAgendamento")
                        .WithMany()
                        .HasForeignKey("StatusAgendamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cabeleleiro");

                    b.Navigation("Cliente");

                    b.Navigation("Servico");

                    b.Navigation("StatusAgendamento");
                });

            modelBuilder.Entity("backend.Models.Avaliacao", b =>
                {
                    b.HasOne("backend.Models.Cabeleleiro", "Cabeleleiro")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("CabeleleiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.Usuario", "Cliente")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cabeleleiro");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("backend.Models.Cabeleleiro", b =>
                {
                    b.HasOne("backend.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("backend.Models.CabeleleiroEspecialidade", b =>
                {
                    b.HasOne("backend.Models.Cabeleleiro", "Cabeleleiro")
                        .WithMany("Especialidades")
                        .HasForeignKey("CabeleleiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.Servico", "Servico")
                        .WithMany()
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cabeleleiro");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("backend.Models.Pagamento", b =>
                {
                    b.HasOne("backend.Models.Agendamento", "Agendamento")
                        .WithOne("Pagamento")
                        .HasForeignKey("backend.Models.Pagamento", "AgendamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.MetodoPagamento", "MetodoPagamento")
                        .WithMany()
                        .HasForeignKey("MetodoPagamentoId");

                    b.HasOne("backend.Models.StatusPagamento", "StatusPagamento")
                        .WithMany()
                        .HasForeignKey("StatusPagamentoId");

                    b.Navigation("Agendamento");

                    b.Navigation("MetodoPagamento");

                    b.Navigation("StatusPagamento");
                });

            modelBuilder.Entity("backend.Models.Servico", b =>
                {
                    b.HasOne("backend.Models.Agendamento", null)
                        .WithMany("Servicos")
                        .HasForeignKey("AgendamentoId");

                    b.HasOne("backend.Models.Cabeleleiro", "Cabeleleiro")
                        .WithMany("Servicos")
                        .HasForeignKey("CabeleleiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.TipoServico", "TipoServico")
                        .WithMany()
                        .HasForeignKey("TipoServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cabeleleiro");

                    b.Navigation("TipoServico");
                });

            modelBuilder.Entity("backend.Models.TipoUsuario", b =>
                {
                    b.HasOne("backend.Models.Usuario", null)
                        .WithMany("TipoUsuarios")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("backend.Models.Agendamento", b =>
                {
                    b.Navigation("Pagamento");

                    b.Navigation("Servicos");
                });

            modelBuilder.Entity("backend.Models.Cabeleleiro", b =>
                {
                    b.Navigation("Agendamentos");

                    b.Navigation("Avaliacoes");

                    b.Navigation("Especialidades");

                    b.Navigation("Servicos");
                });

            modelBuilder.Entity("backend.Models.Servico", b =>
                {
                    b.Navigation("Agendamentos");
                });

            modelBuilder.Entity("backend.Models.Usuario", b =>
                {
                    b.Navigation("Agendamentos");

                    b.Navigation("Avaliacoes");

                    b.Navigation("TipoUsuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
