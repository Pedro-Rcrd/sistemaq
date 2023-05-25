using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class Tutorium
{
    public int CodigoTutoria { get; set; }

    public int CodigoCurso { get; set; }

    public int CodigoArea { get; set; }

    public int CodigoTutor { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string HoraInicio { get; set; } = null!;

    public string HoraFinal { get; set; } = null!;

    public string Tema { get; set; } = null!;

    public virtual Area CodigoAreaNavigation { get; set; } = null!;

    public virtual Curso CodigoCursoNavigation { get; set; } = null!;

    public virtual Tutor CodigoTutorNavigation { get; set; } = null!;

    public virtual ICollection<EstudianteTutorium> EstudianteTutoria { get; set; } = new List<EstudianteTutorium>();

    public virtual ICollection<TutorTurorium> TutorTuroria { get; set; } = new List<TutorTurorium>();
}
