using System.ComponentModel.DataAnnotations;

namespace XPTO.Models
{
    public class User
    {
        [Key]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(6, ErrorMessage = "Este campo deve conter entre 6 e 32 caracteres")]
        [MaxLength(32, ErrorMessage = "Este campo deve conter entre 6 e 32 caracteres")]
        public string Password { get; set; }
    }
}