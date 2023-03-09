using DALcsPharma.Modelo;
using TorreControlCspharma.DTO;

namespace pruebaFuncionamiento.DTOs
{
    public class DaoToDto
    {
        public EmpleadoDTO DaoToDtoempleado(DlkCatAccEmpleado empleado)
        {
            EmpleadoDTO empleadoDTO = new EmpleadoDTO
            {
                CodEmpleado = empleado.CodEmpleado,
                ClaveEmpleado = empleado.ClaveEmpleado,
                IdEmpleado = (int)empleado.IdEmpleado,
                NivelAcceso = empleado.NivelAcceso,
                EmailEmpleado = empleado.EmailEmpleado,
                MdDate = empleado.MdDate,
                MdUid= empleado.MdUid,
            };
            return empleadoDTO;
        }
   
     public EstadoPedidoDTO DaoToDtoEstadoPedido(TdcTchEstadoPedido Estado)
    {
        EstadoPedidoDTO EstadoPedidoDTO = new EstadoPedidoDTO
        {
            IdPedido= Estado.IdPedido,
            CodEstadoDevolucion = Estado.CodEstadoDevolucion,
            CodEstadoEnvio = Estado.CodEstadoEnvio,
            CodEstadoPago = Estado.CodEstadoPago,
            CodLinea= Estado.CodLinea,
            CodPedido= Estado.CodPedido,
            MdDate= Estado.MdDate,
            MdUuid= Estado.MdUuid,
            
        };
        return EstadoPedidoDTO;
    }

}
}
