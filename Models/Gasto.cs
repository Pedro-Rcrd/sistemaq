using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class Gasto
{
    public int CodigoGasto { get; set; }

    public int CodigoEstudiante { get; set; }

    public string TipoPago { get; set; } = null!;

    public DateTime FechaEntrega { get; set; }

    public string NumeroDocumento { get; set; } = null!;

    public string Monto { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual Estudiante CodigoEstudianteNavigation { get; set; } = null!;
}
