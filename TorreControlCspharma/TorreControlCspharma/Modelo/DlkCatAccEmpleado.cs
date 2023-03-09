using System;
using System.Collections.Generic;

namespace TorreControlCspharma.Modelo;

public partial class DlkCatAccEmpleado
{
    public string MdUid { get; set; } = null!;

    public DateTime MdDate { get; set; }

    public string CodEmpleado { get; set; } = null!;

    public string ClaveEmpleado { get; set; } = null!;

    public string NivelAcceso { get; set; } = null!;

    public int IdEmpleado { get; set; }

    public string? EmailEmpleado { get; set; }
}
