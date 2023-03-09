using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TorreControlCspharma.Pages.Pedidos
{
    [Authorize(Policy = "ADMINONLY")]
    public class EliminaPedidoModel : PageModel
    {
        private readonly DALcsPharma.Modelo.CspharmaInformacionallContext _context;

        public EliminaPedidoModel(DALcsPharma.Modelo.CspharmaInformacionallContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DALcsPharma.Modelo.TdcTchEstadoPedido TdcTchEstadoPedido { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TdcTchEstadoPedidos == null)
            {
                return NotFound();
            }

            var TdcTchEstadoPedido = await _context.TdcTchEstadoPedidos.FirstOrDefaultAsync(m => m.IdPedido == id);

            if (TdcTchEstadoPedido == null)
            {
                return NotFound();
            }
            else
            {
                this.TdcTchEstadoPedido = TdcTchEstadoPedido;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TdcTchEstadoPedidos == null)
            {
                return NotFound();
            }
            var TdcTchEstadoPedido = await _context.TdcTchEstadoPedidos.FirstOrDefaultAsync(m => m.IdPedido == id);

            if (TdcTchEstadoPedido != null)
            {
                this.TdcTchEstadoPedido = TdcTchEstadoPedido;
                _context.TdcTchEstadoPedidos.Remove(TdcTchEstadoPedido);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
