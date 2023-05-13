using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class HistorialEstudiante
{
    [DisplayName("Historial de Estudiante")]

    public int CodigoHistorialEstudiante { get; set; }
    [DisplayName("Estudiante")]

    public int CodigoEstudiante { get; set; }
    [DisplayName("Nivel Académico")]

    public int CodigoNivelAcademico { get; set; }
    [DisplayName("Grado")]

    public int CodigoGrado { get; set; }
    [DisplayName("Carrera")]

    public int CodigoCarrera { get; set; }
    [DisplayName("Establecimiento")]

    public int CodigoEstablecimiento { get; set; }
    [DisplayName("Fecha de Creación")]

    public DateTime FechaCreacion { get; set; }

    public virtual Carrera CodigoCarreraNavigation { get; set; } = null!;

    public virtual Establecimiento CodigoEstablecimientoNavigation { get; set; } = null!;

    public virtual Estudiante CodigoEstudianteNavigation { get; set; } = null!;

    public virtual Grado CodigoGradoNavigation { get; set; } = null!;

    public virtual NivelAcademico CodigoNivelAcademicoNavigation { get; set; } = null!;
}
