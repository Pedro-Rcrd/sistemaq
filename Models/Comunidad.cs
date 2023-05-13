using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class Comunidad
{
    [DisplayName("Comunidad")]

    public int CodigoComunidad { get; set; }
    [DisplayName("Nombre")]

    public string NombreComunidad { get; set; } = null!;

    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
}
