using System;
using System.Collections.Generic;

namespace DALcsPharma.Modelo;

public partial class DlkCatAccEmpleado
{
    public string? MdUid { get; set; }

    public DateTime MdDate { get; set; }

    public string CodEmpleado { get; set; } = null!;

    public string ClaveEmpleado { get; set; } = null!;

    public string? NivelAcceso { get; set; }

    public int IdEmpleado { get; set; }

    public string? EmailEmpleado { get; set; }
}
