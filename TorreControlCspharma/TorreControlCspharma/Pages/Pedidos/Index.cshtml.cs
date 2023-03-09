using DALcsPharma.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace TorreControlCspharma.Pages.Pedidos
{
    [Authorize(Policy = "ADMINORUSER")]
    
    public class IndexModel : PageModel
    {
        private readonly CspharmaInformacionallContext _context;

        public IndexModel(CspharmaInformacionallContext context)
        {
            _context = context;
        }

        public IList<TdcTchEstadoPedido> TdcTchEstadoPedido { get; set; } = new List<TdcTchEstadoPedido>();

        public async Task OnGetAsync()
        {
            //Estado Pedido
            TdcTchEstadoPedido = await _context.TdcTchEstadoPedidos.Include(t => t.CodEstadoEnvioNavigation)
                    .Include(t => t.CodLineaNavigation)
                    .Include(t => t.CodEstadoDevolucionNavigation)
                    .Include(t => t.CodEstadoPagoNavigation)
                    .ToListAsync();
        }

       
    }
}

