using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class Tutor
{
    [DisplayName("Tutor")]

    public int CodigoTutor { get; set; }

    [DisplayName("Profesión")]

    public int CodigoProfesion { get; set; }

    [DisplayName("Nombre")]


    public string Nombre { get; set; } = null!;
    [DisplayName("Apellido")]


    public string Apellido { get; set; } = null!;
    [DisplayName("Teléfono")]


    public string Telefono { get; set; } = null!;

    [DisplayName("E-mail")]

    public string Email { get; set; } = null!;
    [DisplayName("Fecha de Creación")]

    public DateTime FechaCreacion { get; set; }
    [DisplayName("Profesión")]

    public virtual Profesion CodigoProfesionNavigation { get; set; } = null!;
    [DisplayName("Tutor y Tutoria")]

    public virtual ICollection<TutorTurorium> TutorTuroria { get; set; } = new List<TutorTurorium>();
    [DisplayName("Tutoria")]

    public virtual ICollection<Tutorium> Tutoria { get; set; } = new List<Tutorium>();
}

