using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class NivelAcademico
{
    [DisplayName("Nivel Académico")]

    public int CodigoNivelAcademico { get; set; }
    [DisplayName("Nombre")]

    public string Nombre { get; set; } = null!;
    [DisplayName("Historial de Estudiantes ")]

    public virtual ICollection<HistorialEstudiante> HistorialEstudiantes { get; set; } = new List<HistorialEstudiante>();

    public virtual ICollection<Patrocinador> Patrocinadors { get; set; } = new List<Patrocinador>();
}
