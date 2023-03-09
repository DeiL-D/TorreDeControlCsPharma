using DALcsPharma.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TorreControlCspharma.Modelo;

namespace TorreControlCspharma.Pages.Auth
{
    [Authorize(Policy = "ADMINONLY")]
    public class EliminaUserModel : PageModel
    {
        private readonly DALcsPharma.Modelo.CspharmaInformacionallContext _context;

        public EliminaUserModel(DALcsPharma.Modelo.CspharmaInformacionallContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DALcsPharma.Modelo.DlkCatAccEmpleado DlkCatAccEmpleado { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DlkCatAccEmpleados == null)
            {
                return NotFound();
            }

            var dlkCatAccEmpleado = await _context.DlkCatAccEmpleados.FirstOrDefaultAsync(m => m.IdEmpleado == id);

            if (dlkCatAccEmpleado == null)
            {
                return NotFound();
            }
            else
            {
                DlkCatAccEmpleado = DlkCatAccEmpleado;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            try {
                if (id == null || _context.DlkCatAccEmpleados == null)
                {
                    return NotFound();
                }
                var DlkCatAccEmpleado = await _context.DlkCatAccEmpleados.FirstOrDefaultAsync(m => m.IdEmpleado == id);

                if (DlkCatAccEmpleado != null)
                {
                    this.DlkCatAccEmpleado = DlkCatAccEmpleado;
                    _context.DlkCatAccEmpleados.Remove(DlkCatAccEmpleado);
                    await _context.SaveChangesAsync();
                }

                return RedirectToPage("./AltaUsuario");
            }
            catch(Exception ex)
            {
                return RedirectToPage("/ErrorPage");
            }
            }
    }
}
