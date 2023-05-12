using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class NivelAcademico
{
    public int CodigoNivelAcademico { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<HistorialEstudiante> HistorialEstudiantes { get; set; } = new List<HistorialEstudiante>();

    public virtual ICollection<Patrocinador> Patrocinadors { get; set; } = new List<Patrocinador>();
}
