using System;
using System.Collections.Generic;

namespace DALcsPharma.Modelo;

public partial class TdcCatLineasDistribucion
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
    /// Identificador
    /// unívoco de la
    /// línea de
    /// distribución en el
    /// sistema
    /// </summary>
    public int IdLineasDistribucion { get; set; }

    /// <summary>
    /// Código que
    /// identifica de forma
    /// unívoca la línea
    /// de distribución por
    /// carretera que
    /// sigue el envío:
    /// codprovincia-cod
    /// municipio-codbarri
    /// o
    /// </summary>
    public string CodLinea { get; set; } = null!;

    /// <summary>
    /// Código que
    /// identifica de forma
    /// unívoca a la
    /// provincia
    /// </summary>
    public string CodProvincia { get; set; } = null!;

    /// <summary>
    /// Código que
    /// identifica de forma
    /// unívoca el
    /// municipio
    /// </summary>
    public string CodMunicipio { get; set; } = null!;

    /// <summary>
    /// Código que
    /// identifica de forma
    /// unívoca el barrio
    /// </summary>
    public string CodBarrio { get; set; } = null!;

    public DateTime MdDate { get; set; }

    public virtual ICollection<TdcTchEstadoPedido> TdcTchEstadoPedidos { get; } = new List<TdcTchEstadoPedido>();
}
