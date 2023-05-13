using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class Desempeño
{
    [DisplayName("Desempeño")]

    public int CodigoDesempeño { get; set; }
    [DisplayName("Nombre")]

    public string? Nombre { get; set; }

    public virtual ICollection<FichaCalificacion> FichaCalificacions { get; set; } = new List<FichaCalificacion>();
}
