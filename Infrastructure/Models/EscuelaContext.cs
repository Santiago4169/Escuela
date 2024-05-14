using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Models
{
    public  class EscuelaContext : DbContext
    {
        public EscuelaContext()
        {
        }

        public EscuelaContext(DbContextOptions<EscuelaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; } = null!;
        public virtual DbSet<AlumnoProfesor> AlumnoProfesors { get; set; } = null!;
        public virtual DbSet<Carrera> Carreras { get; set; } = null!;
        public virtual DbSet<MateriaAlumno> MateriaAlumnos { get; set; } = null!;
        public virtual DbSet<MateriaProfesor> MateriaProfesors { get; set; } = null!;
        public virtual DbSet<Materium> Materia { get; set; } = null!;
        public virtual DbSet<Profesor> Profesors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-6U5LP0A;Database=Escuela;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.CodigoAlumno)
                    .HasName("pk_ca");

                entity.ToTable("Alumno");

                entity.Property(e => e.CodigoAlumno).ValueGeneratedNever();

                entity.Property(e => e.GeneroAlumno)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NombreAlumno)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoCarrera1Navigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.CodigoCarrera1)
                    .HasConstraintName("pk_fc1");
            });

            modelBuilder.Entity<AlumnoProfesor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AlumnoProfesor");

                entity.HasOne(d => d.CodigoAlumno1Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoAlumno1)
                    .HasConstraintName("pk_fCodigoAlumno1");

                entity.HasOne(d => d.CodigoProfesor1Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoProfesor1)
                    .HasConstraintName("pk_fCodigoProfesor1");
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.CodigoCarrera)
                    .HasName("pk_cc");

                entity.ToTable("Carrera");

                entity.Property(e => e.CodigoCarrera).ValueGeneratedNever();

                entity.Property(e => e.NombreCarrera)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MateriaAlumno>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MateriaAlumno");

                entity.HasOne(d => d.CodigoAlumno2Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoAlumno2)
                    .HasConstraintName("pk_fCodigoAlumno2");

                entity.HasOne(d => d.CodigoMateria1Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoMateria1)
                    .HasConstraintName("pk_fCodigoMateria1");
            });

            modelBuilder.Entity<MateriaProfesor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MateriaProfesor");

                entity.HasOne(d => d.CodigoMateria2Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoMateria2)
                    .HasConstraintName("pk_fCodigoMateria2");

                entity.HasOne(d => d.CodigoProfesor2Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoProfesor2)
                    .HasConstraintName("pk_fCodigoProfesor2");
            });

            modelBuilder.Entity<Materium>(entity =>
            {
                entity.HasKey(e => e.CodigoMateria)
                    .HasName("pk_cm");

                entity.Property(e => e.CodigoMateria).ValueGeneratedNever();

                entity.Property(e => e.NombreMateria)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => e.CodigoProfesor)
                    .HasName("pk_cp");

                entity.ToTable("Profesor");

                entity.Property(e => e.CodigoProfesor).ValueGeneratedNever();

                entity.Property(e => e.DireccionProfesor)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.HorarioProfesor).HasColumnType("datetime");

                entity.Property(e => e.NombreProfesor)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
