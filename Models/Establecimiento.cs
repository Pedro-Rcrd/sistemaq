using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class Establecimiento
{
    public int CodigoEstablecimiento { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<HistorialEstudiante> HistorialEstudiantes { get; set; } = new List<HistorialEstudiante>();
}
