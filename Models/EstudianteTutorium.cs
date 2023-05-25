using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class EstudianteTutorium
{
    public int CodigoEstudianteTutoria { get; set; }

    public int CodigoEstudiante { get; set; }

    public int CodigoTutoria { get; set; }

    public virtual Estudiante CodigoEstudianteNavigation { get; set; } = null!;

    public virtual Tutorium CodigoTutoriaNavigation { get; set; } = null!;
}
