using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class TutorTurorium
{
    [DisplayName("Código de Tutor de Tutoría")]

    public int CodigoTutorTutoria { get; set; }
    [DisplayName("Código de Tutor")]


    public int CodigoTutor { get; set; }

    [DisplayName("Código de Tutoría")]  


    public int CodigoTutoria { get; set; }

    public virtual Tutor CodigoTutorNavigation { get; set; } = null!;

    public virtual Tutorium CodigoTutoriaNavigation { get; set; } = null!;
}
 