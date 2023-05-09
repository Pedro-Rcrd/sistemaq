using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class Estudiante
{
    [DisplayName("Código de Estudiante")]

    public int CodigoEstudiante { get; set; }
    
    [DisplayName("Código de Comunidad")]
    public int CodigoComunidad { get; set; }


    [DisplayName("Nombre")]

    public string Nombre { get; set; } = null!;

    [DisplayName("Apellido")]

    public string Apellido { get; set; } = null!;

    [DisplayName("Fecha de Nacimiento")]

    public DateTime? FechaNacimieto { get; set; }

    [DisplayName("Genero")]

    public string Genero { get; set; } = null!;
    
    [DisplayName("Estado")]

    public string Estado { get; set; } = null!;

    [DisplayName("Sector")]

    public int? Sector { get; set; }

    [DisplayName("Numero de Casa")]

    public string NumeroCasa { get; set; } = null!;
   
    [DisplayName("Descripción")]

    public string Descripcion { get; set; } = null!;

    [DisplayName("Foto de Perfil")]

    public string FotoPerfil { get; set; } = null!;

    [DisplayName("Fecha de Creación")]


    public DateTime? FechaCreacion { get; set; }

    [DisplayName("Código de Comunidad de Navegación")]

    public virtual Comunidad CodigoComunidadNavigation { get; set; } = null!;

    public virtual ICollection<EstudiantePatrocinador> EstudiantePatrocinadors { get; set; } = new List<EstudiantePatrocinador>();

    public virtual ICollection<EstudianteTutorium> EstudianteTutoria { get; set; } = new List<EstudianteTutorium>();

    public virtual ICollection<FichaCalificacion> FichaCalificacions { get; set; } = new List<FichaCalificacion>();

    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();

    public virtual ICollection<HistorialEstudiante> HistorialEstudiantes { get; set; } = new List<HistorialEstudiante>();

    public virtual ICollection<OrdenCompra> OrdenCompras { get; set; } = new List<OrdenCompra>();
}
