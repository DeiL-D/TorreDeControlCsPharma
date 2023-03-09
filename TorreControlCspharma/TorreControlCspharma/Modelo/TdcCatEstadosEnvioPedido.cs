using System;
using System.Collections.Generic;

namespace TorreControlCspharma.Modelo;

public partial class TdcCatEstadosEnvioPedido
{
    public string MdUuid { get; set; } = null!;

    public DateTime MdDate { get; set; }

    public int IdEnvio { get; set; }

    public string CodEstadoEnvio { get; set; } = null!;

    public string? DesEstadoEnvio { get; set; }
}
