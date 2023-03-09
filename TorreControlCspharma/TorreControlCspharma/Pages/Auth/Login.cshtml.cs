using DALcsPharma.Modelo;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using TorreControlCspharma.DTO;
using Microsoft.AspNetCore.Components.Web;
using TorreControlCspharma.Utilities;

namespace TorreControlCspharma.Pages.Auth
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly CspharmaInformacionallContext context_;
        private readonly UserManager<EmpleadoDTO> _userManager;
        private  Encrypt encrypt = new Encrypt() ;
        

        public LoginModel(UserManager<EmpleadoDTO> userManager, CspharmaInformacionallContext context)
        {
            _userManager = userManager;
            context_ = context;
        }
        public IList<DlkCatAccEmpleado> DlkCatAccEmpleado { get; set; } = new List<DlkCatAccEmpleado>();
        [BindProperty]
        public EmpleadoDTO empleado { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
            try {
                if (ModelState.IsValid)
                {

                    // Verifico las credenciales utilizando el encriptado para poder verificar la contraseña correctamente

                    var user = context_.DlkCatAccEmpleados
                        .FirstOrDefault(u => u.CodEmpleado == empleado.CodEmpleado && u.ClaveEmpleado == encrypt.Encripter(empleado.ClaveEmpleado));


                    //asignamos asincronamente el rol con el usermanager

                    if (user != null)
                    {
                        Console.Write(user.CodEmpleado + user.ClaveEmpleado + user.NivelAcceso);
                        //utilizamos autentificacion, creacion y asignacion de reclamaciones para guardad las cookies de sesion para poder loguearse automaticamente
                        //la proxima vez que entre
                        var claims = new List<Claim>
                        {
                             new Claim(ClaimTypes.Name, empleado.CodEmpleado),
                             new Claim("Password", empleado.ClaveEmpleado),
                             new Claim(ClaimTypes.Role, user.NivelAcceso)
                        };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);

                        //configuramos el inicio de sesion con los datos de las cookies y especificamos que solo
                        //esten disponibles 45 minutos por los cuales se iniciara sesion automaticamente
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                        {
                            ExpiresUtc = DateTime.Now.AddMinutes(45)
                        });
                        // Iniciar sesión aquí guardando el rol y user en sesion
                        HttpContext.Session.SetString("UserName", empleado.CodEmpleado);
                        HttpContext.Session.SetString("Rol", user.NivelAcceso);

                        //Redireccionamiento a la pagina post login
                        return RedirectToPage("/Index");

                    }
                    else
                    {
                        ErrorMessage = "Usuario o contraseña inválidos";
                        ModelState.AddModelError("", "Usuario o contraseña inválidos");
                    }
                }

                return Page();

            }
            catch(Exception ex)
            {
                return RedirectToPage("/ErrorPage");
            }
            }
            
        }
    }

