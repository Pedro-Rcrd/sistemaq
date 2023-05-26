using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class Rol
{
    public int CodigoRol { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();
}
