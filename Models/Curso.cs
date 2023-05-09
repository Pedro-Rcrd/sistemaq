using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class Curso
{
    [DisplayName("Código de Curso")]

    public int CodigoCurso { get; set; }
    [DisplayName("Nombre")]

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Tutorium> Tutoria { get; set; } = new List<Tutorium>();
}
