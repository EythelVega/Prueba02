using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Prueba02.Models.dbModels
{
    public partial class ProyectoContext : IdentityDbContext<ApplicationUser, IdentityRole<int>,int>
    {
        public ProyectoContext()
        {
        }

        public ProyectoContext(DbContextOptions<ProyectoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Grupo> Grupos { get; set; } = null!;
        public virtual DbSet<GrupoEstudiante> GrupoEstudiantes { get; set; } = null!;
        public virtual DbSet<HoraClase> HoraClases { get; set; } = null!;
        public virtual DbSet<HoraClase1> HoraClases1 { get; set; } = null!;
        public virtual DbSet<ImagenesError> ImagenesErrors { get; set; } = null!;
        public virtual DbSet<Materium> Materia { get; set; } = null!;
        public virtual DbSet<Noticia> Noticias { get; set; } = null!;
        public virtual DbSet<ReporteError> ReporteErrors { get; set; } = null!;
        public virtual DbSet<TipoNoticia> TipoNoticias { get; set; } = null!;
        
      



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.IdGrupo)
                    .HasName("PK_TablaGrupo");

                entity.HasOne(d => d.HoraFinNavigation)
                    .WithMany(p => p.GrupoHoraFinNavigations)
                    .HasForeignKey(d => d.HoraFin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grupo_HoraClase2");

                entity.HasOne(d => d.HoraInicioNavigation)
                    .WithMany(p => p.GrupoHoraInicioNavigations)
                    .HasForeignKey(d => d.HoraInicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grupo_HoraClase1");

                entity.HasOne(d => d.IdMaestroNavigation)
                    .WithMany(p => p.Grupos)
                    .HasForeignKey(d => d.IdMaestro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grupo_Usuario");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.Grupos)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grupo_HoraClase");
            });

            modelBuilder.Entity<GrupoEstudiante>(entity =>
            {
                entity.HasKey(e => new { e.IdGrupo, e.IdEstudiantes });

                entity.HasOne(d => d.IdEstudiantesNavigation)
                    .WithMany(p => p.GrupoEstudiantes)
                    .HasForeignKey(d => d.IdEstudiantes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GrupoEstudiantes_Usuario");

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.GrupoEstudiantes)
                    .HasForeignKey(d => d.IdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GrupoEstudiantes_Grupo");
            });

            modelBuilder.Entity<HoraClase>(entity =>
            {
                entity.Property(e => e.IdHoraClase).ValueGeneratedNever();
            });

            modelBuilder.Entity<HoraClase1>(entity =>
            {
                entity.HasOne(d => d.IdHoraNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdHora)
                    .HasConstraintName("FK__HoraClase__IdHor__59FA5E80");
            });

            modelBuilder.Entity<ImagenesError>(entity =>
            {
                entity.HasOne(d => d.IdErrorNavigation)
                    .WithMany(p => p.ImagenesErrors)
                    .HasForeignKey(d => d.IdError)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ImagenesError_Reporte Error");
            });

            modelBuilder.Entity<Noticia>(entity =>
            {
                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Noticia)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Noticias_Usuario");

                entity.HasOne(d => d.TipoNoticiaNavigation)
                    .WithMany(p => p.Noticia)
                    .HasForeignKey(d => d.TipoNoticia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Noticias_TipoNoticias1");
            });

            modelBuilder.Entity<ReporteError>(entity =>
            {
                entity.HasKey(e => e.IdReporteError)
                    .HasName("PK_Reporte Error");
            });

         
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
