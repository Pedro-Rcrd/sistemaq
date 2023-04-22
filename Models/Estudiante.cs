using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class Estudiante
{
    public int CodigoEstudiante { get; set; }

    public int CodigoComunidad { get; set; }

    public string NombreEstudiante { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateTime FechaNacimieto { get; set; }

    public bool Genero { get; set; }

    public byte Estado { get; set; }

    public string Sector { get; set; } = null!;

    public string NumeroCasa { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Fotografi { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public virtual Comunidad CodigoComunidadNavigation { get; set; } = null!;
}
