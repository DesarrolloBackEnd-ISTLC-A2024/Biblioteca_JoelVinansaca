using System;
using System.Collections.Generic;

namespace Biblioteca_JoelVinansaca.Models;

public partial class PrestamosDetalle
{
    public int IdPrestamo { get; set; }

    public int IdDetalle { get; set; }

    public int? IdLibros { get; set; }

    public string? Estado { get; set; }

    public virtual Libro? IdLibrosNavigation { get; set; }

    public virtual PrestamosCabecera IdPrestamoNavigation { get; set; } = null!;
}
