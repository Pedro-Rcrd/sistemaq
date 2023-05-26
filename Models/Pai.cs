using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class Pai
{
    public int CodigoPais { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Patrocinador> Patrocinadors { get; set; } = new List<Patrocinador>();
}
