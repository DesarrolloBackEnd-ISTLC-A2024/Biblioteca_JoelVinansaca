using System;
using System.Collections.Generic;

namespace Biblioteca_JoelVinansaca.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<PrestamosCabecera> PrestamosCabeceras { get; set; } = new List<PrestamosCabecera>();
}
