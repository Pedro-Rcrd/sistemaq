using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class Pai
{
    [DisplayName("Código País")]

    public int CodigoPais { get; set; }

    [DisplayName("Nombre")]

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Patrocinador> Patrocinadors { get; set; } = new List<Patrocinador>();
}
