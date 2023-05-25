using System;
using System.Collections.Generic;

namespace systemquchooch.Models;

public partial class Usuario
{
    public int CodigoUsuario { get; set; }

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contrasena { get; set; } = null!;
}
