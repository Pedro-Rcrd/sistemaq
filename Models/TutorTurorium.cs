using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class TutorTurorium
{
    [DisplayName("Tutor de Tutoría")]

    public int CodigoTutorTutoria { get; set; }
    [DisplayName("Tutor")]

    public int CodigoTutor { get; set; }
    [DisplayName("Tutoría")]

    public int CodigoTutoria { get; set; }
    [DisplayName("Tutor de Navegación")]

    public virtual Tutor CodigoTutorNavigation { get; set; } = null!;
    [DisplayName("Tutoría de Navegación")]

    public virtual Tutorium CodigoTutoriaNavigation { get; set; } = null!;
}
