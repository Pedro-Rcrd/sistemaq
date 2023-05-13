using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class EstudianteTutorium
{
    [DisplayName("Estudiante de Turoría ")]

    public int CodigoEstudianteTutoria { get; set; }
    [DisplayName("Estudiante ")]

    public int CodigoEstudiante { get; set; }
    [DisplayName("Tutoría ")]

    public int CodigoTutoria { get; set; }
  

    public virtual Estudiante CodigoEstudianteNavigation { get; set; } = null!;

    public virtual Tutorium CodigoTutoriaNavigation { get; set; } = null!;
}
