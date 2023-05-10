using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class OrdenCompra
{
    public int CodigoOrdenCompra { get; set; }

    public int CodigoEstudiante { get; set; }

    public int CodigoProveedor { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? Descripcion { get; set; }

    public virtual Estudiante CodigoEstudianteNavigation { get; set; } = null!;

    public virtual Proveedor CodigoProveedorNavigation { get; set; } = null!;
}
