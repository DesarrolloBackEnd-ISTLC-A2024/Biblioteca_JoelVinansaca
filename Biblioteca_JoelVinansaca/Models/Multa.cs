using System;
using System.Collections.Generic;

namespace Biblioteca_JoelVinansaca.Models;

public partial class Multa
{
    public int IdMulta { get; set; }

    public int? IdPrestamo { get; set; }

    public string? Motivo { get; set; }

    public decimal? Total { get; set; }

    public string? Estado { get; set; }

    public virtual PrestamosCabecera? IdPrestamoNavigation { get; set; }
}
