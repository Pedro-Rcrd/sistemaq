using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class Comunidad
{
    public int CodigoComunidad { get; set; }

    public string NombreComunidad { get; set; } = null!;

    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
}
