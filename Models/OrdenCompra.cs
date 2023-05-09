using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class OrdenCompra
{
    [DisplayName("Código de Orden de Compra")]

    public int CodigoOrdenCompra { get; set; }

    [DisplayName("Código de Estudiante")]


    public int CodigoEstudiante { get; set; }

    [DisplayName("Código de Proveedores")]

    public int CodigoProveedor { get; set; }

    [DisplayName("Fecha de Creación")]

    public DateTime FechaCreacion { get; set; }
    [DisplayName("Descripción")]

    public string? Descripcion { get; set; }

    [DisplayName("Código de Estudiante de Navegación")]


    public virtual Estudiante CodigoEstudianteNavigation { get; set; } = null!;

    [DisplayName("Código de Proveedores de Navegación")]


    public virtual Proveedor CodigoProveedorNavigation { get; set; } = null!;
}
