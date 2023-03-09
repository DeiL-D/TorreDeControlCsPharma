using DALcsPharma.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TorreControlCspharma.Pages.Auth
{
    [Authorize(Policy = "ADMINONLY")]
    public class EditUserModel : PageModel
    {
        private readonly CspharmaInformacionallContext _context;

        public EditUserModel(CspharmaInformacionallContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DlkCatAccEmpleado DlkCatAccEmpleado { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.DlkCatAccEmpleados == null)
            {
                return NotFound();
            }

            var DlkCatAccEmpleado = await _context.DlkCatAccEmpleados.FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (DlkCatAccEmpleado == null)
            {
                return NotFound();
            }
            this.DlkCatAccEmpleado = DlkCatAccEmpleado;
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {

         
            _context.Attach(DlkCatAccEmpleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DlkCatAccEmpleadoExists(DlkCatAccEmpleado.IdEmpleado))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./AltaUsuario");
        }

        private bool DlkCatAccEmpleadoExists(long id)
        {
            return _context.DlkCatAccEmpleados.Any(e => e.IdEmpleado == id);
        }
    }
}
