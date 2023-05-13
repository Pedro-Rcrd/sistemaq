using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class Profesion
{
    [DisplayName("Profesión")]

    public int CodigoProfesion { get; set; }
    [DisplayName("Nombre")]

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Tutor> Tutors { get; set; } = new List<Tutor>();
}
