using Microsoft.AspNetCore.Identity;

namespace TorreControlCspharma.DTO
{
    /*
     * EmpleadoDTO: Clase que se utiliza para poder trabajar con las propiedades de base de datos de una manera mas segura añadiendo una capa de seguridad 
     */
    public class EmpleadoDTO : IdentityUser<int>
    {
        //Constructor Para Empleados Normal
        public EmpleadoDTO(string mdUid, DateTime mdDate, string codEmpleado, string claveEmpleado, string nivelAcceso, string? emailEmpleado)
        {
            MdUid = mdUid;
            MdDate = mdDate;
            CodEmpleado = codEmpleado;
            ClaveEmpleado = claveEmpleado;
            NivelAcceso = nivelAcceso;
            IdEmpleado = IdEmpleado;
            EmailEmpleado = emailEmpleado;
            
            
        }
        //Constructor Para Empleados Login
        public EmpleadoDTO( string codEmpleado, string claveEmpleado, string nivelAcceso)
        {
            
            CodEmpleado = codEmpleado;
            ClaveEmpleado = claveEmpleado;
           
        }
        //Constructor Para Empleados Vacio
        public EmpleadoDTO()
        {
          
        }
        //Propiedades
        public string? MdUid { get; set; } 

        public DateTime MdDate { get; set; }

        public string CodEmpleado { get; set; } = null!;

        public string ClaveEmpleado { get; set; } = null!;

        public string? NivelAcceso { get; set; } 

        public int IdEmpleado { get; set; }

        public string? EmailEmpleado { get; set; }


   

    }
}
