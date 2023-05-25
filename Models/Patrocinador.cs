using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class Patrocinador
{
    public int CodigoPatrocinador { get; set; }

    public int CodigoPais { get; set; }

    public int CodigoNivelAcademico { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string FotoPerfil { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual NivelAcademico CodigoNivelAcademicoNavigation { get; set; } = null!;

    public virtual Pai CodigoPaisNavigation { get; set; } = null!;

    public virtual ICollection<EstudiantePatrocinador> EstudiantePatrocinadors { get; set; } = new List<EstudiantePatrocinador>();
}
