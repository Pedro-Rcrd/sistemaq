using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class Curso
{
    public int CodigoCurso { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Tutorium> Tutoria { get; set; } = new List<Tutorium>();
}
