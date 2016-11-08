using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace THOT.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "¿Recordarme en este navegador?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Correo Electrónico")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Recordar Datos")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Debe haber al menos {2} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password, ErrorMessage = "PRUEBA")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password", ErrorMessage = "No coincide datos de Contraseña")]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Sólo se admiten letras")]
        [MaxLength(50), MinLength(3)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Sólo se admiten letras")]
        [MaxLength(50), MinLength(3)]
        [Display(Name = "Apellido Paterno")]
        public string FirstLastName { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Sólo se admiten letras")]
        [MaxLength(50), MinLength(3)]
        [Display(Name = "Apellido Materno")]
        public string SecondLastName { get; set; }
        [Required]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Sólo se admiten digitos")]
        [Display(Name = "Número de Boleta")]
        [StringLength(10, ErrorMessage = "El numero de boleta se conforma por 10 digitos")]
        public string StudentId { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Debe haber al menos {2} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password", ErrorMessage = "No coincide datos de Contraseña")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }
    }
}
