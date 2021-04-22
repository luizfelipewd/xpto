using System;
using System.ComponentModel.DataAnnotations;

namespace XPTO.Models
{
    public class OS
    {
        public OS(Guid oSNumber, string title, string customerCNPJ, string customerName, string workerCPF, string workerName, decimal price, DateTime date)
        {
            OSNumber = oSNumber;
            Title = title;
            CustomerCNPJ = customerCNPJ;
            CustomerName = customerName;
            WorkerCPF = workerCPF;
            WorkerName = workerName;
            Price = price;
            Date = date;
        }

        [Key]
        public Guid OSNumber { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        public string Title { get; private set; }

        [Required(ErrorMessage = "CNPJ do cliente é obrigatório")]
        [MinLength(14, ErrorMessage = "Este campo deve conter 14 caracteres")]
        [MaxLength(14, ErrorMessage = "Este campo deve conter 14 caracteres")]
        public string CustomerCNPJ { get; private set; }

        [Required(ErrorMessage = "Nome do cliente é obrigatório")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        public string CustomerName { get; private set; }

        [Required(ErrorMessage = "CPF do prestador de serviço é obrigatório")]
        [MinLength(11, ErrorMessage = "Este campo deve conter 11 caracteres")]
        [MaxLength(11, ErrorMessage = "Este campo deve conter 11 caracteres")]
        public string WorkerCPF { get; private set; }

        [Required(ErrorMessage = "Nome do prestador de serviço é obrigatório")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        public string WorkerName { get; private set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Campo obrigatório")]
        public decimal Price { get; private set; }
        public DateTime Date { get; private set; }
    }
}