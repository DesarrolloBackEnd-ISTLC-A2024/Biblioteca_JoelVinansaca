using System;
using System.Collections.Generic;

namespace Biblioteca_JoelVinansaca.Models;

public partial class Editorial
{
    public int IdEditorial { get; set; }

    public string? NombreEditorial { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
