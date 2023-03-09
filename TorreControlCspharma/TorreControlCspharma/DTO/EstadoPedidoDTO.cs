using DALcsPharma.Modelo;

namespace TorreControlCspharma.DTO
{
    public class EstadoPedidoDTO
    {
        public EstadoPedidoDTO(string mdUuid, int idPedido, string? codEstadoEnvio, string? codEstadoPago, string? codEstadoDevolucion, string codPedido, string codLinea, DateTime mdDate)
        {
            MdUuid = mdUuid;
            IdPedido = idPedido;
            CodEstadoEnvio = codEstadoEnvio;
            CodEstadoPago = codEstadoPago;
            CodEstadoDevolucion = codEstadoDevolucion;
            CodPedido = codPedido;
            CodLinea = codLinea;
            MdDate = mdDate;
        }
        public EstadoPedidoDTO()
        {
           
        }

        public string MdUuid { get; set; } = null!;

       
        public int IdPedido { get; set; }

        public string? CodEstadoEnvio { get; set; }

      
        public string? CodEstadoPago { get; set; }

        
        public string? CodEstadoDevolucion { get; set; }

        public string CodPedido { get; set; } = null!;

      
        public string CodLinea { get; set; } = null!;

        public DateTime MdDate { get; set; }

        public virtual TdcCatEstadosDevolucionPedido? CodEstadoDevolucionNavigation { get; set; }

        public virtual TdcCatEstadosEnvioPedido? CodEstadoEnvioNavigation { get; set; }

        public virtual TdcCatEstadosPagoPedido? CodEstadoPagoNavigation { get; set; }

        public virtual TdcCatLineasDistribucion CodLineaNavigation { get; set; } = null!;
    }
}
