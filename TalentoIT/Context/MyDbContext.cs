using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TalentoIT.Entities;

#nullable disable

namespace TalentoIT.Context
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<perfil_detalhe> perfil_detalhes { get; set; }
        public virtual DbSet<perfil_talento> perfil_talentos { get; set; }
        public virtual DbSet<proposta_skill> proposta_skills { get; set; }
        public virtual DbSet<proposta_user> proposta_users { get; set; }
        public virtual DbSet<propostum> proposta { get; set; }
        public virtual DbSet<skill> skills { get; set; }
        public virtual DbSet<talento_skill> talento_skills { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<user_skill> user_skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;port=5432;Database=postgres;Username=postgres;Password=postgrespw");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<perfil_detalhe>(entity =>
            {
                entity.HasKey(e => e.id_perfil_detalhe)
                    .HasName("id_perfil_detalhe");

                entity.HasOne(d => d.id_perfil_talentoNavigation)
                    .WithMany(p => p.perfil_detalhes)
                    .HasForeignKey(d => d.id_perfil_talento)
                    .HasConstraintName("id_perfil_talento_fk");
            });

            modelBuilder.Entity<perfil_talento>(entity =>
            {
                entity.HasKey(e => e.id_perfil_talento)
                    .HasName("id_perfil_talento");

                entity.HasOne(d => d.id_userNavigation)
                    .WithMany(p => p.perfil_talentos)
                    .HasForeignKey(d => d.id_user)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_user_fk");
            });

            modelBuilder.Entity<proposta_skill>(entity =>
            {
                entity.HasKey(e => e.id_proposta_skill)
                    .HasName("id_proposta_skill");

                entity.HasOne(d => d.id_propostaNavigation)
                    .WithMany(p => p.proposta_skills)
                    .HasForeignKey(d => d.id_proposta)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_proposta_fk");

                entity.HasOne(d => d.id_skillNavigation)
                    .WithMany(p => p.proposta_skills)
                    .HasForeignKey(d => d.id_skill)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_skill_fk");
            });

            modelBuilder.Entity<proposta_user>(entity =>
            {
                entity.HasKey(e => e.id_proposta_user)
                    .HasName("id_proposta_user");

                entity.HasOne(d => d.id_propostaNavigation)
                    .WithMany(p => p.proposta_users)
                    .HasForeignKey(d => d.id_proposta)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_proposta_fk");

                entity.HasOne(d => d.id_userNavigation)
                    .WithMany(p => p.proposta_users)
                    .HasForeignKey(d => d.id_user)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_user_fk");
            });

            modelBuilder.Entity<propostum>(entity =>
            {
                entity.HasKey(e => e.id_proposta)
                    .HasName("id_proposta");
            });

            modelBuilder.Entity<skill>(entity =>
            {
                entity.HasKey(e => e.id_skill)
                    .HasName("id_skill");
            });

            modelBuilder.Entity<talento_skill>(entity =>
            {
                entity.HasKey(e => e.id_talento_skill)
                    .HasName("id_talento_skill");

                entity.HasOne(d => d.id_perfil_talentoNavigation)
                    .WithMany(p => p.talento_skills)
                    .HasForeignKey(d => d.id_perfil_talento)
                    .HasConstraintName("id_perfil_talento_fk");

                entity.HasOne(d => d.id_skillNavigation)
                    .WithMany(p => p.talento_skills)
                    .HasForeignKey(d => d.id_skill)
                    .HasConstraintName("id_skill_fk");
            });

            modelBuilder.Entity<user>(entity =>
            {
                entity.HasKey(e => e.id_user)
                    .HasName("id_user");
            });

            modelBuilder.Entity<user_skill>(entity =>
            {
                entity.HasKey(e => e.id_user_skill)
                    .HasName("id_user_skill");

                entity.HasOne(d => d.id_skillNavigation)
                    .WithMany(p => p.user_skills)
                    .HasForeignKey(d => d.id_skill)
                    .HasConstraintName("id_skill_fk");

                entity.HasOne(d => d.id_userNavigation)
                    .WithMany(p => p.user_skills)
                    .HasForeignKey(d => d.id_user)
                    .HasConstraintName("id_user_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
