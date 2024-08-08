using System;
using System.Collections.Generic;

namespace Biblioteca_JoelVinansaca.Models;

public partial class Libro
{
    public int IdLibros { get; set; }

    public string? Nombre { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdAutor { get; set; }

    public int? IdEditorial { get; set; }

    public string? Estado { get; set; }

    public virtual Autor? IdAutorNavigation { get; set; }

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual Editorial? IdEditorialNavigation { get; set; }

    public virtual Inventario? Inventario { get; set; }

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();

    public virtual ICollection<Novedade> Novedades { get; set; } = new List<Novedade>();

    public virtual ICollection<PrestamosDetalle> PrestamosDetalles { get; set; } = new List<PrestamosDetalle>();
}
