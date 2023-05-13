using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class Gasto
{
    [DisplayName("Gasto")]

    public int CodigoGasto { get; set; }
    [DisplayName("Estudiante")]

    public int CodigoEstudiante { get; set; }
    [DisplayName("Tipo de Pago")]

    public string TipoPago { get; set; } = null!;
    [DisplayName("Fecha de Entega")]

    public DateTime FechaEntrega { get; set; }
    [DisplayName("Numero de Documento")]

    public string NumeroDocumento { get; set; } = null!;
    [DisplayName("Monto")]

    public string Monto { get; set; } = null!;
    [DisplayName("Descripción")]

    public string Descripcion { get; set; } = null!;

    public virtual Estudiante CodigoEstudianteNavigation { get; set; } = null!;
}
