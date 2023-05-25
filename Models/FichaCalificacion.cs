using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class FichaCalificacion
{
    public int CodigoFichaCalificacion { get; set; }

    public int CodigoEstudiante { get; set; }

    public int CodigoPeriodo { get; set; }

    public int CodigoDesempeño { get; set; }

    public DateTime FechaEntrega { get; set; }

    public string Notas { get; set; } = null!;

    public int Promedio { get; set; }

    public string ImagenFicha { get; set; } = null!;

    public string ImagenEstudiante { get; set; } = null!;

    public string ImagenCarta { get; set; } = null!;

    public virtual Desempeño CodigoDesempeñoNavigation { get; set; } = null!;

    public virtual Estudiante CodigoEstudianteNavigation { get; set; } = null!;

    public virtual Periodo CodigoPeriodoNavigation { get; set; } = null!;

    public virtual ICollection<ImagenAdicional> ImagenAdicionals { get; set; } = new List<ImagenAdicional>();
}
