using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class ImagenAdicional
{
    public int CodigoImagenAdicional { get; set; }

    public int CodigoFichaCalificacion { get; set; }

    public string ImgAdicional { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual FichaCalificacion CodigoFichaCalificacionNavigation { get; set; } = null!;
}
