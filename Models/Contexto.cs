using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SiteCCZ.Models
{
    public partial class Contexto : DbContext
    {
        public Contexto()
        {
        }

        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {
        }

        public virtual DbSet<Animaisachados> Animaisachados { get; set; }
        public virtual DbSet<Animaisccz> Animaisccz { get; set; }
        public virtual DbSet<Animaisperdidos> Animaisperdidos { get; set; }
        public virtual DbSet<Animaisvacinas> Animaisvacinas { get; set; }
        public virtual DbSet<Animaisvermifugos> Animaisvermifugos { get; set; }
        public virtual DbSet<Contatosadocao> Contatosadocao { get; set; }
        public virtual DbSet<Equipeccz> Equipeccz { get; set; }
        public virtual DbSet<Postsblog> Postsblog { get; set; }
        public virtual DbSet<Vacinas> Vacinas { get; set; }
        public virtual DbSet<Vermifugos> Vermifugos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animaisachados>(entity =>
            {
                entity.HasKey(e => e.IdAnimalAchado)
                    .HasName("PRIMARY");

                entity.ToTable("animaisachados");

                entity.Property(e => e.IdAnimalAchado).HasColumnType("int(11)");

                entity.Property(e => e.AchadorNome)
                    .HasColumnName("Achador_Nome")
                    .HasColumnType("varchar(80)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.AchadorTelefone)
                    .HasColumnName("Achador_Telefone")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Bairro)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.DescricaoFoto)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Detalhes)
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Especie)
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Foto)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Raca)
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Animaisccz>(entity =>
            {
                entity.HasKey(e => e.IdAnimal)
                    .HasName("PRIMARY");

                entity.ToTable("animaisccz");

                entity.Property(e => e.IdAnimal).HasColumnType("int(11)");

                entity.Property(e => e.Adotavel)
                    .HasColumnType("varchar(3)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Cor)
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Especie)
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Foto)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Historia)
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.IdadeAprox)
                    .HasColumnType("varchar(2)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Nome)
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Porte)
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Raca)
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Sexo)
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.StatusAnimal)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Animaisperdidos>(entity =>
            {
                entity.HasKey(e => e.IdAnimalPerdido)
                    .HasName("PRIMARY");

                entity.ToTable("animaisperdidos");

                entity.Property(e => e.IdAnimalPerdido).HasColumnType("int(11)");

                entity.Property(e => e.Detalhes)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Especie)
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Foto)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Nome)
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Raca)
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.TelefoneDono)
                    .HasColumnName("Telefone_Dono")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Animaisvacinas>(entity =>
            {
                entity.HasKey(e => e.IdAnimalVacina)
                    .HasName("PRIMARY");

                entity.ToTable("animaisvacinas");

                entity.HasIndex(e => e.IdAnimal)
                    .HasName("IdAnimal");

                entity.HasIndex(e => e.IdVacina)
                    .HasName("IdVacina");

                entity.Property(e => e.IdAnimalVacina).HasColumnType("int(11)");

                entity.Property(e => e.DataProxVacina).HasColumnType("date");

                entity.Property(e => e.DataVacina).HasColumnType("date");

                entity.Property(e => e.IdAnimal).HasColumnType("int(11)");

                entity.Property(e => e.IdVacina).HasColumnType("int(11)");

                entity.HasOne(d => d.IdAnimalNavigation)
                    .WithMany(p => p.Animaisvacinas)
                    .HasForeignKey(d => d.IdAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("animaisvacinas_ibfk_1");

                entity.HasOne(d => d.IdVacinaNavigation)
                    .WithMany(p => p.Animaisvacinas)
                    .HasForeignKey(d => d.IdVacina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("animaisvacinas_ibfk_2");
            });

            modelBuilder.Entity<Animaisvermifugos>(entity =>
            {
                entity.HasKey(e => e.IdAnimalVermifugo)
                    .HasName("PRIMARY");

                entity.ToTable("animaisvermifugos");

                entity.HasIndex(e => e.IdAnimal)
                    .HasName("IdAnimal");

                entity.HasIndex(e => e.IdVermifugo)
                    .HasName("IdVermifugo");

                entity.Property(e => e.IdAnimalVermifugo).HasColumnType("int(11)");

                entity.Property(e => e.DataProxVermifugo).HasColumnType("date");

                entity.Property(e => e.DataVermifugo).HasColumnType("date");

                entity.Property(e => e.IdAnimal).HasColumnType("int(11)");

                entity.Property(e => e.IdVermifugo).HasColumnType("int(11)");

                entity.HasOne(d => d.IdAnimalNavigation)
                    .WithMany(p => p.Animaisvermifugos)
                    .HasForeignKey(d => d.IdAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("animaisvermifugos_ibfk_1");

                entity.HasOne(d => d.IdVermifugoNavigation)
                    .WithMany(p => p.Animaisvermifugos)
                    .HasForeignKey(d => d.IdVermifugo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("animaisvermifugos_ibfk_2");
            });

            modelBuilder.Entity<Contatosadocao>(entity =>
            {
                entity.HasKey(e => e.IdContatoAdocao)
                    .HasName("PRIMARY");

                entity.ToTable("contatosadocao");

                entity.HasIndex(e => e.IdAnimal)
                    .HasName("IdAnimal");

                entity.Property(e => e.IdContatoAdocao).HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.IdAnimal).HasColumnType("int(11)");

                entity.Property(e => e.Justificativa)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Nome)
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Telefone)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.IdAnimalNavigation)
                    .WithMany(p => p.Contatosadocao)
                    .HasForeignKey(d => d.IdAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("contatosadocao_ibfk_1");
            });

            modelBuilder.Entity<Equipeccz>(entity =>
            {
                entity.HasKey(e => e.IdColaborador)
                    .HasName("PRIMARY");

                entity.ToTable("equipeccz");

                entity.Property(e => e.IdColaborador).HasColumnType("int(11)");

                entity.Property(e => e.Cargo)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Nome)
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Postsblog>(entity =>
            {
                entity.HasKey(e => e.IdPostBlog)
                    .HasName("PRIMARY");

                entity.ToTable("postsblog");

                entity.Property(e => e.IdPostBlog).HasColumnType("int(11)");

                entity.Property(e => e.OlhoPost)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Autor)
                    .HasColumnType("varchar(80)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Conteudo)
                    .HasColumnType("varchar(5000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.DataPublicacao).HasColumnType("datetime");

                entity.Property(e => e.DescricaoImagem)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Imagem)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Titulo)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.OlhoPost)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Vacinas>(entity =>
            {
                entity.HasKey(e => e.IdVacina)
                    .HasName("PRIMARY");

                entity.ToTable("vacinas");

                entity.Property(e => e.IdVacina).HasColumnType("int(11)");

                entity.Property(e => e.Doses).HasColumnType("int(2)");

                entity.Property(e => e.Nome)
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Periodicidade).HasColumnType("int(2)");
            });

            modelBuilder.Entity<Vermifugos>(entity =>
            {
                entity.HasKey(e => e.IdVermifugo)
                    .HasName("PRIMARY");

                entity.ToTable("vermifugos");

                entity.Property(e => e.IdVermifugo).HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Periodicidade).HasColumnType("int(2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
