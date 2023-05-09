using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class FichaCalificacion
{
    [DisplayName("Código de Ficha de Calificación")]

    public int CodigoFichaCalificacion { get; set; }

    [DisplayName("Código de Estudiante")]

    public int CodigoEstudiante { get; set; }

    [DisplayName("Código de Periodo")]

    public int CodigoPeriodo { get; set; }

    [DisplayName("Código de Desempeño")]


    public int CodigoDesempeño { get; set; }

    [DisplayName("Fecha de Entrega")]


    public DateTime FechaEntrega { get; set; }

    [DisplayName("Notas")]

    public string Notas { get; set; } = null!;


    [DisplayName("Promedio")]

    public int Promedio { get; set; }

    [DisplayName("Imagen de Ficha")]


    public string ImagenFicha { get; set; } = null!;

    [DisplayName("Imagen de Estudiante")]


    public string ImagenEstudiante { get; set; } = null!;

    [DisplayName("Imagen de Carta")]


    public string ImagenCarta { get; set; } = null!;

    [DisplayName("Código de Desempeño de Navegación")]


    public virtual Desempeño CodigoDesempeñoNavigation { get; set; } = null!;

    [DisplayName("Código de Estudiante de Navegación")]

    public virtual Estudiante CodigoEstudianteNavigation { get; set; } = null!;
    [DisplayName("Código de Periodo de Navegación")]


    public virtual Periodo CodigoPeriodoNavigation { get; set; } = null!;

    [DisplayName("Imagen Adicionales")]


    public virtual ICollection<ImagenAdicional> ImagenAdicionals { get; set; } = new List<ImagenAdicional>();
}
