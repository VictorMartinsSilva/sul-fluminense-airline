using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SFA.Site.ViewModels
{
    public class AddressViewModels
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Rua")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O campo {0} deve conter de {2} a {1} caracteres.")]
        public string Street { get; set; }

        [DisplayName("Bairro")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O campo {0} deve conter de {2} a {1} caracteres.")]
        public string District { get; set; }

        [DisplayName("Cidade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O campo {0} deve conter de {2} a {1} caracteres.")]
        public string City { get; set; }

        [DisplayName("País")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O campo {0} deve conter de {2} a {1} caracteres.")]
        public string Country { get; set; }

        [DisplayName("Estado")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O campo {0} deve conter de {2} a {1} caracteres.")]
        public string State { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O campo {0} deve conter de {2} a {1} caracteres.")]
        public string UF { get; set; }

        [DisplayName("Número")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Number { get; set; }

        [DisplayName("CEP")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(9, MinimumLength = 8, ErrorMessage = "O campo {0} deve conter de {2} a {1} caracteres.")]
        public string PostalCode { get; set; }

        [DisplayName("Complemento")]
        public string Complement { get; set; }
        public PassengerViewModels Passenger { get; set; }
    }
}
