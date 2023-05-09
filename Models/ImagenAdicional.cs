using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class ImagenAdicional
{
    [DisplayName("Código de Imagen Adiciional")]

    public int CodigoImagenAdicional { get; set; }

    [DisplayName("Código Ficha de Calificación")]

    public int CodigoFichaCalificacion { get; set; }

    [DisplayName("Imagen Adicional")]

    public string ImgAdicional { get; set; } = null!;

    [DisplayName("Descripción")]


    public string Descripcion { get; set; } = null!;

    [DisplayName("Código de Ficha de Calificación de Navegación")]


    public virtual FichaCalificacion CodigoFichaCalificacionNavigation { get; set; } = null!;
}

