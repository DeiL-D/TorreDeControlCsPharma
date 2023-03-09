using DALcsPharma.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using System.Security.Cryptography.Xml;
using TorreControlCspharma.DTO;
using TorreControlCspharma.Utilities;

namespace TorreControlCspharma.Pages.Auth
{
    [Authorize(Policy = "ADMINONLY")]

    public class AltaUsuarioModel : PageModel
    {
       
        //instanciamientos de necesidades
        private readonly CspharmaInformacionallContext context_;
        private readonly UserManager<EmpleadoDTO> _userManager;
        private readonly SignInManager<EmpleadoDTO> _signInManager;
        //private readonly EmailSenderr _emailSender;
        //private readonly EncryptedKey encrypterKey;
        private  Encrypt encrypt = new Encrypt();
        private readonly EmailSenderr _emailSender;
        public AltaUsuarioModel(UserManager<EmpleadoDTO> userManager, SignInManager<EmpleadoDTO> signInManager, CspharmaInformacionallContext context, EmailSenderr emailSender/*CorreoSender correoSender */)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            context_ = context;
            _emailSender = emailSender;
            //cpSender = correoSender;
        }
        public IList<DlkCatAccEmpleado> DlkCatAccEmpleado { get; set; } = new List<DlkCatAccEmpleado>();


        [BindProperty]
        public EmpleadoDTO empleado { get; set; }

        public DlkCatAccEmpleado DaoEmpleados = new DlkCatAccEmpleado();

        public async Task OnGetAsync()
        {
            
                //Usuarios
                DlkCatAccEmpleado = await context_.DlkCatAccEmpleados.ToListAsync();
           
           
        }


        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Guid mduid = Guid.NewGuid();
                    var user = new EmpleadoDTO(
                     mdUid: mduid.ToString(),
                     mdDate: DateTime.Now,
                     codEmpleado: empleado.CodEmpleado,
                     claveEmpleado: encrypt.Encripter(empleado.ClaveEmpleado),
                     nivelAcceso: "0",
                     emailEmpleado: empleado.EmailEmpleado
                     );

                    DaoEmpleados = new DtoToDao().DtoToDAOempleado(user);
                    context_.DlkCatAccEmpleados.Add(DaoEmpleados);
                    context_.SaveChanges();

                    // Envía correo de confirmación
                    var email = DaoEmpleados.EmailEmpleado;
                    var subject = "Confirmación de cuenta";
                    var message = $"Por favor, confirme su cuenta haciendo clic en este enlace: <a href='http://localhost:5000/Auth/ConfirmEmail?userId={DaoEmpleados.IdEmpleado}&email={email}'>Confirmar cuenta</a>";

                    await _emailSender.SendEmailAsync(email, subject, message);

                    return RedirectToPage("/Auth/AltaUsuario");
                }
                else
                {
                    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        // Mostrar el mensaje de error en la vista
                        Console.WriteLine(error.ErrorMessage);
                    }
                }

                return Page();
            }
            catch (Exception ex)
            {
                // redirige a la página de error
                return Redirect("/Auth/ErrorCreateUser");
            }
        }

    }
}


