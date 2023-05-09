using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class Patrocinador
{
    [DisplayName("Código de Patrocinador")]

    public int CodigoPatrocinador { get; set; }

    [DisplayName("Código País")]

    public int CodigoPais { get; set; }

    [DisplayName("Código de Nivel Acedémico")]

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


    public virtual NivelAcademico CodigoNivelAcademicoNavigation { get; set; } = null!;

    public virtual Pai CodigoPaisNavigation { get; set; } = null!;

    public virtual ICollection<EstudiantePatrocinador> EstudiantePatrocinadors { get; set; } = new List<EstudiantePatrocinador>();
}
