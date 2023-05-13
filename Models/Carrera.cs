using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class Carrera
{
    [DisplayName("Carrera")]

    public int CodigoCarrera { get; set; }
    [DisplayName("Nombre")]
    public string Nombre { get; set; } = null!;

    public virtual ICollection<HistorialEstudiante> HistorialEstudiantes { get; set; } = new List<HistorialEstudiante>();
}
