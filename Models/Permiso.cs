using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class Permiso
{
    public int CodigoPermiso { get; set; }

    public int CodigoRol { get; set; }

    public int CodigoModulo { get; set; }

    public virtual Modulo CodigoModuloNavigation { get; set; } = null!;

    public virtual Rol CodigoRolNavigation { get; set; } = null!;
}
