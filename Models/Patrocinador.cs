using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class Patrocinador
{
  
    [DisplayName("País")]

    public int CodigoPais { get; set; }
    [DisplayName("Nivel Acedémico")]

    public int CodigoNivelAcademico { get; set; }
    [DisplayName("Nombre")]

    public string Nombre { get; set; } = null!;
    [DisplayName("Apellido")]

    public string Apellido { get; set; } = null!;
    [DisplayName("Estado")]

    public string Estado { get; set; } = null!;
    [DisplayName("Foto de Perfil")]

    public string FotoPerfil { get; set; } = null!;
    [DisplayName("Fecha de Nacimiento")]

    public DateTime FechaNacimiento { get; set; }
    [DisplayName("Fecha de Creación")]

    public DateTime FechaCreacion { get; set; }
    [DisplayName("Patrocinador")]

    public int CodigoPatrocinador { get; set; }
    [DisplayName("Nivel Académico de Navigation")]

    public virtual NivelAcademico CodigoNivelAcademicoNavigation { get; set; } = null!;
    [DisplayName("País de Navegación")]
    public virtual Pai CodigoPaisNavigation { get; set; } = null!;

    public virtual ICollection<EstudiantePatrocinador> EstudiantePatrocinadors { get; set; } = new List<EstudiantePatrocinador>();
}
