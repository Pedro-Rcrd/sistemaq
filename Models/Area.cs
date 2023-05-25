using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class Area
{
    public int CodigoArea { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Tutorium> Tutoria { get; set; } = new List<Tutorium>();
}
