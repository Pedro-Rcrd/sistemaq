using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class Periodo
{
    [DisplayName("Periodo")]

    public int CodigoPeriodo { get; set; }
    [DisplayName("Nombre")]

    public string Nombre { get; set; } = null!;

    public virtual ICollection<FichaCalificacion> FichaCalificacions { get; set; } = new List<FichaCalificacion>();
}
