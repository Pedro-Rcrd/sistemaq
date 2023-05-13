using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class EstudiantePatrocinador
{
    [DisplayName("Estudiante y Patrocinador")]
    public int CodigoEstudiantePatrocinador { get; set; }
    [DisplayName("Estudiante")]

    public int CodigoEstudiante { get; set; }
    [DisplayName("Patrocinador")]

    public int CodigoPatrocinador { get; set; }

    public virtual Estudiante CodigoEstudianteNavigation { get; set; } = null!;

    public virtual Patrocinador CodigoPatrocinadorNavigation { get; set; } = null!;
}
