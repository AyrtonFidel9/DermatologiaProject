//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppDermatologia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Empleado
    {
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Usuario")]
        [StringLength(60, MinimumLength = 5)]
        public string Login { get; set; }
       

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
       

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Servicio")]
        [RegularExpression("Estética|Dermatología", ErrorMessage = "Solo se admite un caractér el servicio de Estética y Dermatología")]
        public string Rol_Servicio { get; set; }
        

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Nombre")]
        [StringLength(60, MinimumLength = 3)]
        public string Nombre { get; set; }


      

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Apellido")]
        [StringLength(60, MinimumLength = 3)]
        public string Apellido { get; set; }


      

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Correo")]
        [EmailAddress(ErrorMessage = "Dirección de correo inválida")]
        public string Correo { get; set; }


       

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Teléfono")]
        [StringLength(10, MinimumLength = 7)]
        public string Telefono { get; set; }
       
        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Cédula")]
        [RegularExpression("[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]", ErrorMessage = "La cédula ingresada debe contener 10 dígitos")]
        public string Cedula { get; set; }
        
    }

}
