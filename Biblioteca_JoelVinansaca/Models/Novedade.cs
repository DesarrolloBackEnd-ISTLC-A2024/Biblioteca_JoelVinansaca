using System;
using System.Collections.Generic;

namespace Biblioteca_JoelVinansaca.Models;

public partial class Novedade
{
    public int IdNovedad { get; set; }

    public int? IdLibros { get; set; }

    public string? Motivo { get; set; }

    public string? Estado { get; set; }

    public virtual Libro? IdLibrosNavigation { get; set; }
}
