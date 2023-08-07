using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GPTapp.Models
{
    public partial class GestionProyectosTareasDBContext : DbContext
    {
        public GestionProyectosTareasDBContext(DbContextOptions<GestionProyectosTareasDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AsignacionTarea> AsignacionTareas { get; set; } = null!;
        public virtual DbSet<Proyecto> Proyectos { get; set; } = null!;
        public virtual DbSet<Tarea> Tareas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AsignacionTarea>(entity =>
            {
                entity.Property(e => e.FechaAsignacion).HasColumnType("datetime");

                entity.Property(e => e.FechaLimite).HasColumnType("datetime");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.ToTable("Proyecto");
           
                entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            });

            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.ToTable("Tarea");

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.Titulo).HasMaxLength(255);

                entity.Property(e => e.UsuarioId).HasMaxLength(450);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.ContraseñaUsuario).HasMaxLength(50);

                entity.Property(e => e.NombreUsuario).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
