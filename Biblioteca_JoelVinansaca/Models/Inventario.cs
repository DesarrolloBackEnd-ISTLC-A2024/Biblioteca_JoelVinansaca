using System;
using System.Collections.Generic;

namespace Biblioteca_JoelVinansaca.Models;

public partial class Inventario
{
    public int IdLibros { get; set; }

    public int? TotalStock { get; set; }

    public int? StockMinimo { get; set; }

    public int? StockMaximo { get; set; }

    public string? Estado { get; set; }

    public virtual Libro IdLibrosNavigation { get; set; } = null!;
}
