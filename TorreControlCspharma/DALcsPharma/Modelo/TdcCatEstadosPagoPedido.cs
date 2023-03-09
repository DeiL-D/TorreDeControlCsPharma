using System;
using System.Collections.Generic;

namespace DALcsPharma.Modelo;

public partial class TdcCatEstadosPagoPedido
{
    /// <summary>
    /// Código de
    /// metadato
    /// que indica el
    /// grupo
    /// de inserción al
    /// que
    /// pertenece el
    /// registro.
    /// </summary>
    public string MdUuid { get; set; } = null!;

    /// <summary>
    /// Fecha en la que
    /// se
    /// define el grupo de
    /// inserción.
    /// </summary>
    public DateTime MdDate { get; set; }

    /// <summary>
    /// Fecha en la que
    /// se
    /// define el grupo de
    /// inserción.
    /// </summary>
    public int IdPago { get; set; }

    /// <summary>
    /// Código que
    /// identifica de forma
    /// unívoca el estado
    /// de pago de un
    /// pedido
    /// </summary>
    public string CodEstadoPago { get; set; } = null!;

    /// <summary>
    /// Descripción del
    /// estado de pago
    /// del pedido
    /// </summary>
    public string? DesEstadoPago { get; set; }

    public virtual ICollection<TdcTchEstadoPedido> TdcTchEstadoPedidos { get; } = new List<TdcTchEstadoPedido>();
}
