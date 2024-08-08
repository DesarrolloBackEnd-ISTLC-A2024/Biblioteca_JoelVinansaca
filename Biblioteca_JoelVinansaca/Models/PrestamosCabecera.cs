using System;
using System.Collections.Generic;

namespace Biblioteca_JoelVinansaca.Models;

public partial class PrestamosCabecera
{
    public int IdPrestamo { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? FechaPrestamo { get; set; }

    public DateTime? FechaEstimadaDevolucion { get; set; }

    public DateTime? FechaRealDevolucion { get; set; }

    public int? TotalLibrosPrestados { get; set; }

    public string? Observacion { get; set; }

    public string? Estado { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Multa> Multa { get; set; } = new List<Multa>();

    public virtual ICollection<PrestamosDetalle> PrestamosDetalles { get; set; } = new List<PrestamosDetalle>();
}
