using DALcsPharma.Modelo;

namespace TorreControlCspharma.DTO
{
    public class DtoToDao
    {
        public DlkCatAccEmpleado DtoToDAOempleado(EmpleadoDTO empleado)
        {
            DlkCatAccEmpleado empleadoDAL = new DlkCatAccEmpleado
            {
                CodEmpleado = empleado.CodEmpleado,
                ClaveEmpleado = empleado.ClaveEmpleado,
                IdEmpleado = (int)empleado.IdEmpleado,
                NivelAcceso = empleado.NivelAcceso,
                EmailEmpleado = empleado.EmailEmpleado,
                MdDate = empleado.MdDate,
                MdUid = empleado.MdUid,
            };
            return empleadoDAL;
        }
        public  TdcTchEstadoPedido DtoToDAOEstadoPedido(EstadoPedidoDTO Estado)
        {
            TdcTchEstadoPedido EstadoPedidoDAO = new TdcTchEstadoPedido
            {
                IdPedido = Estado.IdPedido,
                CodEstadoDevolucion = Estado.CodEstadoDevolucion,
                CodEstadoEnvio = Estado.CodEstadoEnvio,
                CodEstadoPago = Estado.CodEstadoPago,
                CodLinea = Estado.CodLinea,
                CodPedido = Estado.CodPedido,
                MdDate = Estado.MdDate,
                MdUuid = Estado.MdUuid,

            };
            return EstadoPedidoDAO;
        }
    }
}
