﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace systemquchooch.Models;

public partial class Grado
{
    [DisplayName("Grado")]

    public int CodigoGrado { get; set; }
    [DisplayName("Nombre")]

    public string Nombre { get; set; } = null!;
    [DisplayName("Historial de Estudiantes")]

    public virtual ICollection<HistorialEstudiante> HistorialEstudiantes { get; set; } = new List<HistorialEstudiante>();
}
