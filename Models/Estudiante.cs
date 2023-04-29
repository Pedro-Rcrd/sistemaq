using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class Estudiante
{
    public int CodigoEstudiante { get; set; }

    public int CodigoComunidad { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateTime? FechaNacimieto { get; set; }

    public string Genero { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public int? Sector { get; set; }

    public string NumeroCasa { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string FotoPerfil { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public virtual Comunidad CodigoComunidadNavigation { get; set; } = null!;

    public virtual ICollection<EstudiantePatrocinador> EstudiantePatrocinadors { get; set; } = new List<EstudiantePatrocinador>();

    public virtual ICollection<EstudianteTutorium> EstudianteTutoria { get; set; } = new List<EstudianteTutorium>();

    public virtual ICollection<FichaCalificacion> FichaCalificacions { get; set; } = new List<FichaCalificacion>();

    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();

    public virtual ICollection<HistorialEstudiante> HistorialEstudiantes { get; set; } = new List<HistorialEstudiante>();

    public virtual ICollection<OrdenCompra> OrdenCompras { get; set; } = new List<OrdenCompra>();
}
