using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class ImagenAdicional
{
    [DisplayName("Imagen Adiciional")]

    public int CodigoImagenAdicional { get; set; }
    [DisplayName("Ficha de Calificación")]

    public int CodigoFichaCalificacion { get; set; }
    [DisplayName("Imagen Adicional")]

    public string ImgAdicional { get; set; } = null!;
    [DisplayName("Descripción")]

    public string Descripcion { get; set; } = null!;

    public virtual FichaCalificacion CodigoFichaCalificacionNavigation { get; set; } = null!;
}
