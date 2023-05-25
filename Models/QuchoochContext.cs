using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace systemquchooch.Models;

public partial class QuchoochContext : DbContext
{
    internal object Usuarios;

    public QuchoochContext()
    {
    }

    public QuchoochContext(DbContextOptions<QuchoochContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Carrera> Carreras { get; set; }

    public virtual DbSet<Comunidad> Comunidads { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Desempeño> Desempeños { get; set; }

    public virtual DbSet<Establecimiento> Establecimientos { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<EstudiantePatrocinador> EstudiantePatrocinadors { get; set; }

    public virtual DbSet<EstudianteTutorium> EstudianteTutoria { get; set; }

    public virtual DbSet<FichaCalificacion> FichaCalificacions { get; set; }

    public virtual DbSet<Gasto> Gastos { get; set; }

    public virtual DbSet<Grado> Grados { get; set; }

    public virtual DbSet<HistorialEstudiante> HistorialEstudiantes { get; set; }

    public virtual DbSet<ImagenAdicional> ImagenAdicionals { get; set; }

    public virtual DbSet<NivelAcademico> NivelAcademicos { get; set; }

    public virtual DbSet<OrdenCompra> OrdenCompras { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Patrocinador> Patrocinadors { get; set; }

    public virtual DbSet<Periodo> Periodos { get; set; }

    public virtual DbSet<Profesion> Profesions { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Tutor> Tutors { get; set; }

    public virtual DbSet<TutorTurorium> TutorTuroria { get; set; }

    public virtual DbSet<Tutorium> Tutoria { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //      => optionsBuilder.UseSqlServer("server=localhost; database=quchooch; integrated security=true; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.CodigoArea).HasName("pk_area_codigoArea");

            entity.ToTable("area");

            entity.Property(e => e.CodigoArea).HasColumnName("codigoArea");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(256)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.CodigoCarrera).HasName("pk_carrera_codigoCarrera");

            entity.ToTable("carrera");

            entity.Property(e => e.CodigoCarrera).HasColumnName("codigoCarrera");
            entity.Property(e => e.Nombre)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

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

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.CodigoCurso).HasName("pk_CURSO_codigoCurso");

            entity.ToTable("curso");

            entity.Property(e => e.CodigoCurso).HasColumnName("codigoCurso");
            entity.Property(e => e.Nombre)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Desempeño>(entity =>
        {
            entity.HasKey(e => e.CodigoDesempeño).HasName("pk_desempeño_codigoDesempeño");

            entity.ToTable("desempeño");

            entity.Property(e => e.CodigoDesempeño).HasColumnName("codigoDesempeño");
            entity.Property(e => e.Nombre)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Establecimiento>(entity =>
        {
            entity.HasKey(e => e.CodigoEstablecimiento).HasName("pk_establecimiento_codigoEstablecimiento");

            entity.ToTable("establecimiento");

            entity.Property(e => e.CodigoEstablecimiento).HasColumnName("codigoEstablecimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("nombre");
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
                .HasMaxLength(256)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.FechaNacimieto)
                .HasColumnType("date")
                .HasColumnName("fechaNacimieto");
            entity.Property(e => e.FotoPerfil)
                .HasMaxLength(512)
                .HasColumnName("fotoPerfil");
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.Nombre)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NumeroCasa)
                .HasMaxLength(8)
                .HasColumnName("numeroCasa");
            entity.Property(e => e.Sector).HasColumnName("sector");

            entity.HasOne(d => d.CodigoComunidadNavigation).WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.CodigoComunidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_estudiante_comunidad_codigoComunidad");
        });

        modelBuilder.Entity<EstudiantePatrocinador>(entity =>
        {
            entity.HasKey(e => e.CodigoEstudiantePatrocinador).HasName("pk_estudiantePatrocinador_codigoestudiantePatrocinador");

            entity.ToTable("estudiantePatrocinador");

            entity.Property(e => e.CodigoEstudiantePatrocinador).HasColumnName("codigoEstudiantePatrocinador");
            entity.Property(e => e.CodigoEstudiante).HasColumnName("codigoEstudiante");
            entity.Property(e => e.CodigoPatrocinador).HasColumnName("codigoPatrocinador");

            entity.HasOne(d => d.CodigoEstudianteNavigation).WithMany(p => p.EstudiantePatrocinadors)
                .HasForeignKey(d => d.CodigoEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_estudiantePatrocinador_estudiante_codigoEstudiante");

            entity.HasOne(d => d.CodigoPatrocinadorNavigation).WithMany(p => p.EstudiantePatrocinadors)
                .HasForeignKey(d => d.CodigoPatrocinador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_estudiantePatrocinador_patrocinador_codigoPatrocinador");
        });

        modelBuilder.Entity<EstudianteTutorium>(entity =>
        {
            entity.HasKey(e => e.CodigoEstudianteTutoria).HasName("pk_estudianteTutoria_codigoEstudianteTutoria");

            entity.ToTable("estudianteTutoria");

            entity.Property(e => e.CodigoEstudianteTutoria).HasColumnName("codigoEstudianteTutoria");
            entity.Property(e => e.CodigoEstudiante).HasColumnName("codigoEstudiante");
            entity.Property(e => e.CodigoTutoria).HasColumnName("codigoTutoria");

            entity.HasOne(d => d.CodigoEstudianteNavigation).WithMany(p => p.EstudianteTutoria)
                .HasForeignKey(d => d.CodigoEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_estudianteTutoria_estudiante_codigoEstudiante");

            entity.HasOne(d => d.CodigoTutoriaNavigation).WithMany(p => p.EstudianteTutoria)
                .HasForeignKey(d => d.CodigoTutoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_estudianteTutoria_tutoria_codigoTutoria");
        });

        modelBuilder.Entity<FichaCalificacion>(entity =>
        {
            entity.HasKey(e => e.CodigoFichaCalificacion).HasName("pk_fichaCalificacion_codigoFichaCalificacion");

            entity.ToTable("fichaCalificacion");

            entity.Property(e => e.CodigoFichaCalificacion).HasColumnName("codigoFichaCalificacion");
            entity.Property(e => e.CodigoDesempeño).HasColumnName("codigoDesempeño");
            entity.Property(e => e.CodigoEstudiante).HasColumnName("codigoEstudiante");
            entity.Property(e => e.CodigoPeriodo).HasColumnName("codigoPeriodo");
            entity.Property(e => e.FechaEntrega)
                .HasColumnType("date")
                .HasColumnName("fechaEntrega");
            entity.Property(e => e.ImagenCarta)
                .HasMaxLength(512)
                .HasColumnName("imagenCarta");
            entity.Property(e => e.ImagenEstudiante)
                .HasMaxLength(512)
                .HasColumnName("imagenEstudiante");
            entity.Property(e => e.ImagenFicha)
                .HasMaxLength(512)
                .HasColumnName("imagenFicha");
            entity.Property(e => e.Notas)
                .HasMaxLength(56)
                .HasColumnName("notas");
            entity.Property(e => e.Promedio).HasColumnName("promedio");

            entity.HasOne(d => d.CodigoDesempeñoNavigation).WithMany(p => p.FichaCalificacions)
                .HasForeignKey(d => d.CodigoDesempeño)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_fichaCalificacion_desempeño_codigoDesempeño");

            entity.HasOne(d => d.CodigoEstudianteNavigation).WithMany(p => p.FichaCalificacions)
                .HasForeignKey(d => d.CodigoEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_fichaCalificacion_estudiante_codigoEstudiante");

            entity.HasOne(d => d.CodigoPeriodoNavigation).WithMany(p => p.FichaCalificacions)
                .HasForeignKey(d => d.CodigoPeriodo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_fichaCalificacion_periodo_codigoPeriodo");
        });

        modelBuilder.Entity<Gasto>(entity =>
        {
            entity.HasKey(e => e.CodigoGasto).HasName("pk_gasto_codigoGasto");

            entity.ToTable("gasto");

            entity.Property(e => e.CodigoGasto).HasColumnName("codigoGasto");
            entity.Property(e => e.CodigoEstudiante).HasColumnName("codigoEstudiante");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(256)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaEntrega)
                .HasColumnType("date")
                .HasColumnName("fechaEntrega");
            entity.Property(e => e.Monto)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("monto");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.TipoPago)
                .HasMaxLength(32)
                .HasColumnName("tipoPago");

            entity.HasOne(d => d.CodigoEstudianteNavigation).WithMany(p => p.Gastos)
                .HasForeignKey(d => d.CodigoEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_gasto_estudiante_codigoEstudiante");
        });

        modelBuilder.Entity<Grado>(entity =>
        {
            entity.HasKey(e => e.CodigoGrado).HasName("pk_grado_codigoGrado");

            entity.ToTable("grado");

            entity.Property(e => e.CodigoGrado).HasColumnName("codigoGrado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<HistorialEstudiante>(entity =>
        {
            entity.HasKey(e => e.CodigoHistorialEstudiante).HasName("pk_historialEstudiante_codigoHistorialEstudiante");

            entity.ToTable("historialEstudiante");

            entity.Property(e => e.CodigoHistorialEstudiante).HasColumnName("codigoHistorialEstudiante");
            entity.Property(e => e.CodigoCarrera).HasColumnName("codigoCarrera");
            entity.Property(e => e.CodigoEstablecimiento).HasColumnName("codigoEstablecimiento");
            entity.Property(e => e.CodigoEstudiante).HasColumnName("codigoEstudiante");
            entity.Property(e => e.CodigoGrado).HasColumnName("codigoGrado");
            entity.Property(e => e.CodigoNivelAcademico).HasColumnName("codigoNivelAcademico");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("fechaCreacion");

            entity.HasOne(d => d.CodigoCarreraNavigation).WithMany(p => p.HistorialEstudiantes)
                .HasForeignKey(d => d.CodigoCarrera)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_historialEstudiante_carrera_codigoCarrera");

            entity.HasOne(d => d.CodigoEstablecimientoNavigation).WithMany(p => p.HistorialEstudiantes)
                .HasForeignKey(d => d.CodigoEstablecimiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_historialdEstudiante_establecimiento_codigoEstablecimiento");

            entity.HasOne(d => d.CodigoEstudianteNavigation).WithMany(p => p.HistorialEstudiantes)
                .HasForeignKey(d => d.CodigoEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_historialEstudiante_estudiante_codigoEstudiante");

            entity.HasOne(d => d.CodigoGradoNavigation).WithMany(p => p.HistorialEstudiantes)
                .HasForeignKey(d => d.CodigoGrado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_historialEstudiante_grado_codigoGrado");

            entity.HasOne(d => d.CodigoNivelAcademicoNavigation).WithMany(p => p.HistorialEstudiantes)
                .HasForeignKey(d => d.CodigoNivelAcademico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_historialEstudiante_nivelAcademico_codigoNivelAcademico");
        });

        modelBuilder.Entity<ImagenAdicional>(entity =>
        {
            entity.HasKey(e => e.CodigoImagenAdicional).HasName("pk_imagenAdicional_codigoImagenAdicional");

            entity.ToTable("imagenAdicional");

            entity.Property(e => e.CodigoImagenAdicional).HasColumnName("codigoImagenAdicional");
            entity.Property(e => e.CodigoFichaCalificacion).HasColumnName("codigoFichaCalificacion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.ImgAdicional)
                .HasMaxLength(512)
                .HasColumnName("imgAdicional");

            entity.HasOne(d => d.CodigoFichaCalificacionNavigation).WithMany(p => p.ImagenAdicionals)
                .HasForeignKey(d => d.CodigoFichaCalificacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_imagenAdicional_fichaCalificacion_codigoFichaCalificacion");
        });

        modelBuilder.Entity<NivelAcademico>(entity =>
        {
            entity.HasKey(e => e.CodigoNivelAcademico).HasName("pk_nivelAcademico_codigoNivelAcademico");

            entity.ToTable("nivelAcademico");

            entity.Property(e => e.CodigoNivelAcademico).HasColumnName("codigoNivelAcademico");
            entity.Property(e => e.Nombre)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<OrdenCompra>(entity =>
        {
            entity.HasKey(e => e.CodigoOrdenCompra).HasName("pk_ordenCompra_codigoOrdenCompra");

            entity.ToTable("ordenCompra");

            entity.Property(e => e.CodigoOrdenCompra).HasColumnName("codigoOrdenCompra");
            entity.Property(e => e.CodigoEstudiante).HasColumnName("codigoEstudiante");
            entity.Property(e => e.CodigoProveedor).HasColumnName("codigoProveedor");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(256)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("fechaCreacion");

            entity.HasOne(d => d.CodigoEstudianteNavigation).WithMany(p => p.OrdenCompras)
                .HasForeignKey(d => d.CodigoEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ordenCompra_estudiante_codigoEstudiante");

            entity.HasOne(d => d.CodigoProveedorNavigation).WithMany(p => p.OrdenCompras)
                .HasForeignKey(d => d.CodigoProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ordenCompra_proveedor_codigoProveedor");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.CodigoPais).HasName("pk_pais_codigoPais");

            entity.ToTable("pais");

            entity.Property(e => e.CodigoPais).HasColumnName("codigoPais");
            entity.Property(e => e.Nombre)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Patrocinador>(entity =>
        {
            entity.HasKey(e => e.CodigoPatrocinador).HasName("pk_patrocinador_codigoPatrocinador");

            entity.ToTable("patrocinador");

            entity.Property(e => e.CodigoPatrocinador).HasColumnName("codigoPatrocinador");
            entity.Property(e => e.Apellido)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.CodigoNivelAcademico).HasColumnName("codigoNivelAcademico");
            entity.Property(e => e.CodigoPais).HasColumnName("codigoPais");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fechaNacimiento");
            entity.Property(e => e.FotoPerfil)
                .HasMaxLength(512)
                .HasColumnName("fotoPerfil");
            entity.Property(e => e.Nombre)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.CodigoNivelAcademicoNavigation).WithMany(p => p.Patrocinadors)
                .HasForeignKey(d => d.CodigoNivelAcademico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_patrocinador_nivelAcademico_codigoNivelAcademico");

            entity.HasOne(d => d.CodigoPaisNavigation).WithMany(p => p.Patrocinadors)
                .HasForeignKey(d => d.CodigoPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_patrocinador_pais_codigoPais");
        });

        modelBuilder.Entity<Periodo>(entity =>
        {
            entity.HasKey(e => e.CodigoPeriodo).HasName("pk_periodo_codigoPeriodo");

            entity.ToTable("periodo");

            entity.Property(e => e.CodigoPeriodo).HasColumnName("codigoPeriodo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Profesion>(entity =>
        {
            entity.HasKey(e => e.CodigoProfesion).HasName("pk_profecion_codigoProfesion");

            entity.ToTable("profesion");

            entity.Property(e => e.CodigoProfesion).HasColumnName("codigoProfesion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.CodigoProveedor).HasName("pk_proveedor_codigoProveedor");

            entity.ToTable("proveedor");

            entity.Property(e => e.CodigoProveedor).HasColumnName("codigoProveedor");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Tutor>(entity =>
        {
            entity.HasKey(e => e.CodigoTutor).HasName("pk_tutor_codigoTutor");

            entity.ToTable("tutor");

            entity.Property(e => e.CodigoTutor).HasColumnName("codigoTutor");
            entity.Property(e => e.Apellido)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.CodigoProfesion).HasColumnName("codigoProfesion");
            entity.Property(e => e.Email)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.CodigoProfesionNavigation).WithMany(p => p.Tutors)
                .HasForeignKey(d => d.CodigoProfesion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tutor_profesion_codigoProfesion");
        });

        modelBuilder.Entity<TutorTurorium>(entity =>
        {
            entity.HasKey(e => e.CodigoTutorTutoria).HasName("pk_tutorTuroria_codigoTutorTuroria");

            entity.ToTable("tutorTuroria");

            entity.Property(e => e.CodigoTutorTutoria).HasColumnName("codigoTutorTutoria");
            entity.Property(e => e.CodigoTutor).HasColumnName("codigoTutor");
            entity.Property(e => e.CodigoTutoria).HasColumnName("codigoTutoria");

            entity.HasOne(d => d.CodigoTutorNavigation).WithMany(p => p.TutorTuroria)
                .HasForeignKey(d => d.CodigoTutor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tutorTuroria_tutor_codigoTutor");

            entity.HasOne(d => d.CodigoTutoriaNavigation).WithMany(p => p.TutorTuroria)
                .HasForeignKey(d => d.CodigoTutoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tutorTuroria_tutoria_codigoTutoria");
        });

        modelBuilder.Entity<Tutorium>(entity =>
        {
            entity.HasKey(e => e.CodigoTutoria).HasName("pk_tutoria_codigoTutoria");

            entity.ToTable("tutoria");

            entity.Property(e => e.CodigoTutoria).HasColumnName("codigoTutoria");
            entity.Property(e => e.CodigoArea).HasColumnName("codigoArea");
            entity.Property(e => e.CodigoCurso).HasColumnName("codigoCurso");
            entity.Property(e => e.CodigoTutor).HasColumnName("codigoTutor");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.HoraFinal)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("horaFinal");
            entity.Property(e => e.HoraInicio)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("horaInicio");
            entity.Property(e => e.Tema)
                .HasMaxLength(256)
                .HasColumnName("tema");

            entity.HasOne(d => d.CodigoAreaNavigation).WithMany(p => p.Tutoria)
                .HasForeignKey(d => d.CodigoArea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tutoria_area_codigoArea");

            entity.HasOne(d => d.CodigoCursoNavigation).WithMany(p => p.Tutoria)
                .HasForeignKey(d => d.CodigoCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tutoria_curso_codigoCurso");

            entity.HasOne(d => d.CodigoTutorNavigation).WithMany(p => p.Tutoria)
                .HasForeignKey(d => d.CodigoTutor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tutoria_tutor_codigoTutor");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.CodigoUsuario).HasName("pk_usuario_codigoUsuario");

            entity.ToTable("usuario");

            entity.Property(e => e.CodigoUsuario).HasColumnName("codigoUsuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.Email)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("email");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}