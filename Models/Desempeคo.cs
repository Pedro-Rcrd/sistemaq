using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class Desempeño
{
    public int CodigoDesempeño { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<FichaCalificacion> FichaCalificacions { get; set; } = new List<FichaCalificacion>();
}
