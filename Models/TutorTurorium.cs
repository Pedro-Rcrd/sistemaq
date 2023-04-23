using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class TutorTurorium
{
    public int CodigoTutorTutoria { get; set; }

    public int CodigoTutor { get; set; }

    public int CodigoTutoria { get; set; }

    public virtual Tutor CodigoTutorNavigation { get; set; } = null!;

    public virtual Tutorium CodigoTutoriaNavigation { get; set; } = null!;
}
