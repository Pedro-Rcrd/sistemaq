using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class EstudianteTutorium
{

    [DisplayName("Código de Estudiante de Turoría ")]

    public int CodigoEstudianteTutoria { get; set; }
    [DisplayName("Código de Estudiante ")]

    public int CodigoEstudiante { get; set; }

    [DisplayName("Código de Tutoría ")]

    public int CodigoTutoria { get; set; }

    [DisplayName("Código de Estudiante y Navegación ")]

    public virtual Estudiante CodigoEstudianteNavigation { get; set; } = null!;
    [DisplayName("Código de Tutoría y Navegación ")]

    public virtual Tutorium CodigoTutoriaNavigation { get; set; } = null!;
}
