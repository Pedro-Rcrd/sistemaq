using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace systemquchooch.Models;

public partial class OrdenCompra
{
    [DisplayName("Orden de Compra")]

    public int CodigoOrdenCompra { get; set; }
    [DisplayName("Estudiante")]

    public int CodigoEstudiante { get; set; }
    [DisplayName("Proveedores")]

    public int CodigoProveedor { get; set; }
    [DisplayName("Fecha de Creación")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime FechaCreacion { get; set; }
    [DisplayName("Código de Estudiante de Navegación")]

    public string? Descripcion { get; set; }

    public virtual Estudiante CodigoEstudianteNavigation { get; set; } = null!;

    public virtual Proveedor CodigoProveedorNavigation { get; set; } = null!;
}
