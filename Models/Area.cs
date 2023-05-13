using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class Area
{
    [DisplayName("Área")]

    public int CodigoArea { get; set; }
    [DisplayName("Nombre")]

    public string Nombre { get; set; } = null!;
    [DisplayName("Descripción")]

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Tutorium> Tutoria { get; set; } = new List<Tutorium>();
}
