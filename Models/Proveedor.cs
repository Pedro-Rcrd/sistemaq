using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class Proveedor
{
    public int CodigoProveedor { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<OrdenCompra> OrdenCompras { get; set; } = new List<OrdenCompra>();
}
