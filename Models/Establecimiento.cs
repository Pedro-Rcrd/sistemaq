using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class Establecimiento
{
    [DisplayName("Establecimiento")]

    public int CodigoEstablecimiento { get; set; }
    [DisplayName("Nombre")]
    public string Nombre { get; set; } = null!;

    public virtual ICollection<HistorialEstudiante> HistorialEstudiantes { get; set; } = new List<HistorialEstudiante>();
}
