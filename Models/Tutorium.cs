using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class Tutorium
{
    [DisplayName("Tutoria")]

    public int CodigoTutoria { get; set; }
    [DisplayName("Curso")]

    public int CodigoCurso { get; set; }
    [DisplayName("Área")]

    public int CodigoArea { get; set; }
    [DisplayName("Tutor")]

    public int CodigoTutor { get; set; }
    [DisplayName("Fecha de Creación")]

    public DateTime FechaCreacion { get; set; }
    [DisplayName("Hora de Inicio")]

    public string HoraInicio { get; set; } = null!;
    [DisplayName("Hora de Finalización")]

    public string HoraFinal { get; set; } = null!;
    [DisplayName("Tema")]

    public string Tema { get; set; } = null!;
    [DisplayName("Área de navegación")]

    public virtual Area CodigoAreaNavigation { get; set; } = null!;
    [DisplayName("Curso de navegación")]

    public virtual Curso CodigoCursoNavigation { get; set; } = null!;
    [DisplayName("Tutor de navegación")]

    public virtual Tutor CodigoTutorNavigation { get; set; } = null!;
    [DisplayName("Estudiante y Totoría")]

    public virtual ICollection<EstudianteTutorium> EstudianteTutoria { get; set; } = new List<EstudianteTutorium>();
    [DisplayName("Tutor y Totoría")]

    public virtual ICollection<TutorTurorium> TutorTuroria { get; set; } = new List<TutorTurorium>();
}
