using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class Tutorium
{
    [DisplayName("Código de Tutoria")]

    public int CodigoTutoria { get; set; }
    [DisplayName("Código de Curso")]


    public int CodigoCurso { get; set; }
    [DisplayName("Código de Área")]

    public int CodigoArea { get; set; }

    [DisplayName("Código de Tutor")]

    public int CodigoTutor { get; set; }
    [DisplayName("Código de Creación")]


    public DateTime FechaCreacion { get; set; }
    [DisplayName("Hora de Inicio")]

    public string HoraInicio { get; set; } = null!;
    [DisplayName("Hora de Final")]


    public string HoraFinal { get; set; } = null!;
    [DisplayName("Tema")]
    

    public string Tema { get; set; } = null!;

    public virtual Area CodigoAreaNavigation { get; set; } = null!;

    public virtual Curso CodigoCursoNavigation { get; set; } = null!;

    public virtual Tutor CodigoTutorNavigation { get; set; } = null!;

    public virtual ICollection<EstudianteTutorium> EstudianteTutoria { get; set; } = new List<EstudianteTutorium>();

    public virtual ICollection<TutorTurorium> TutorTuroria { get; set; } = new List<TutorTurorium>();
}
