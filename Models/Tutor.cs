using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class Tutor
{
    public int CodigoTutor { get; set; }

    public int CodigoProfesion { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public virtual Profesion CodigoProfesionNavigation { get; set; } = null!;

    public virtual ICollection<TutorTurorium> TutorTuroria { get; set; } = new List<TutorTurorium>();

    public virtual ICollection<Tutorium> Tutoria { get; set; } = new List<Tutorium>();
}
