using System;
using System.ComponentModel.DataAnnotations;

namespace XPTO.Models
{
    public class OS
    {
        [Key]
        public Guid OSNumber { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "CNPJ do cliente é obrigatório")]
        public string CustomerCNPJ { get; set; }

        [Required(ErrorMessage = "Nome do cliente é obrigatório")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "CPF do prestador de serviço é obrigatório")]
        public string WorkerCPF { get; set; }

        [Required(ErrorMessage = "Nome do prestador de serviço é obrigatório")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        public string WorkerName { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Campo obrigatório")]
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}