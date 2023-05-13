using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class Proveedor
{
    [DisplayName("Proveedor")]

    public int CodigoProveedor { get; set; }
    [DisplayName("Nombre")]

    public string Nombre { get; set; } = null!;
    [DisplayName("Descripción")]

    public string Descripcion { get; set; } = null!;
    [DisplayName("Orden de Compras")]

    public virtual ICollection<OrdenCompra> OrdenCompras { get; set; } = new List<OrdenCompra>();
}
