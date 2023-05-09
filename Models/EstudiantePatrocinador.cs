using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class EstudiantePatrocinador
{
    [DisplayName("Código de Estudiante y Patrocinador")]

    public int CodigoEstudiantePatrocinador { get; set; }

    [DisplayName("Código de Estudiante")]

    public int CodigoEstudiante { get; set; }

    [DisplayName("Código de Patrocinador")]

    public int CodigoPatrocinador { get; set; }

    [DisplayName("Código de Estudiante de Navegación")]
    public virtual Estudiante CodigoEstudianteNavigation { get; set; } = null!;
    [DisplayName("Código de Patrocinador de Navegación")]
    public virtual Patrocinador CodigoPatrocinadorNavigation { get; set; } = null!;
}
