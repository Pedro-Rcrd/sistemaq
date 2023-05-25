using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class Profesion
{
    public int CodigoProfesion { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Tutor> Tutors { get; set; } = new List<Tutor>();
}
