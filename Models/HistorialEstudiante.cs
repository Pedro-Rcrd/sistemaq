using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class HistorialEstudiante
{
    [DisplayName("Código de Historial de Estudiante")] 

    public int CodigoHistorialEstudiante { get; set; }

    [DisplayName("Código de Estudiante")]


    public int CodigoEstudiante { get; set; }
    [DisplayName("Código de Nivel Académico")]

    public int CodigoNivelAcademico { get; set; }

    [DisplayName("Código de Grado")]


    public int CodigoGrado { get; set; }
    [DisplayName("Código de Carrera")]


    public int CodigoCarrera { get; set; }

    [DisplayName("Código de Establecimiento")]


    public int CodigoEstablecimiento { get; set; }

    [DisplayName("Fecha de Creación")]

    public DateTime FechaCreacion { get; set; }

    [DisplayName("Código de Carrera de Navegación")]

    public virtual Carrera CodigoCarreraNavigation { get; set; } = null!;

    [DisplayName("Código de Establecimiento de Navegación")]
    public virtual Establecimiento CodigoEstablecimientoNavigation { get; set; } = null!;
    [DisplayName("Código de Estudiante de Navegación")]

    public virtual Estudiante CodigoEstudianteNavigation { get; set; } = null!;

    [DisplayName("Código de Grado de Navegación")]


    public virtual Grado CodigoGradoNavigation { get; set; } = null!;

    [DisplayName("Código de Nivel Academico de Navegación")]

    public virtual NivelAcademico CodigoNivelAcademicoNavigation { get; set; } = null!;
}
