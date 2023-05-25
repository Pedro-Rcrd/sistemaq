using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class Periodo
{
    public int CodigoPeriodo { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<FichaCalificacion> FichaCalificacions { get; set; } = new List<FichaCalificacion>();
}
