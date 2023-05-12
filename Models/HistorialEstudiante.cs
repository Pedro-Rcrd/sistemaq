using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class HistorialEstudiante
{
    public int CodigoHistorialEstudiante { get; set; }

    public int CodigoEstudiante { get; set; }

    public int CodigoNivelAcademico { get; set; }

    public int CodigoGrado { get; set; }

    public int CodigoCarrera { get; set; }

    public int CodigoEstablecimiento { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Carrera CodigoCarreraNavigation { get; set; } = null!;

    public virtual Establecimiento CodigoEstablecimientoNavigation { get; set; } = null!;

    public virtual Estudiante CodigoEstudianteNavigation { get; set; } = null!;

    public virtual Grado CodigoGradoNavigation { get; set; } = null!;

    public virtual NivelAcademico CodigoNivelAcademicoNavigation { get; set; } = null!;
}
