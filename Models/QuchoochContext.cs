using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace systemquchooch.Models;

public partial class QuchoochContext : DbContext
{
    public QuchoochContext()
    {
    }

    public QuchoochContext(DbContextOptions<QuchoochContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comunidad> Comunidads { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

 //   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
  //      => optionsBuilder.UseSqlServer("server=localhost; database=quchooch; integrated security=true; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comunidad>(entity =>
        {
            entity.HasKey(e => e.CodigoComunidad).HasName("pk_comunidad_codigoComunidad");

            entity.ToTable("comunidad");

            entity.Property(e => e.CodigoComunidad).HasColumnName("codigoComunidad");
            entity.Property(e => e.NombreComunidad)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("nombreComunidad");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.CodigoEstudiante).HasName("pk_estudiante_codigoEstudiante");

            entity.ToTable("estudiante");

            entity.Property(e => e.CodigoEstudiante).HasColumnName("codigoEstudiante");
            entity.Property(e => e.Apellido)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.CodigoComunidad).HasColumnName("codigoComunidad");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(512)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.FechaNacimieto)
                .HasColumnType("date")
                .HasColumnName("fechaNacimieto");
            entity.Property(e => e.Fotografi)
                .HasMaxLength(512)
                .HasColumnName("fotografi");
            entity.Property(e => e.Genero).HasColumnName("genero");
            entity.Property(e => e.NombreEstudiante)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("nombreEstudiante");
            entity.Property(e => e.NumeroCasa)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("numeroCasa");
            entity.Property(e => e.Sector)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("sector");

            entity.HasOne(d => d.CodigoComunidadNavigation).WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.CodigoComunidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_estudiante_comunidad_codigoComunidad");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
