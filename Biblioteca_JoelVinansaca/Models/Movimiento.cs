using System;
using System.Collections.Generic;

namespace Biblioteca_JoelVinansaca.Models;

public partial class Movimiento
{
    public int IdMovimiento { get; set; }

    public int? IdLibros { get; set; }

    public int? Cantidad { get; set; }

    public string? TipoMovimiento { get; set; }

    public string? Estado { get; set; }

    public virtual Libro? IdLibrosNavigation { get; set; }
}
