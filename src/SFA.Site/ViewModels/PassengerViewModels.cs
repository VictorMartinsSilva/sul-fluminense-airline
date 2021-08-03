using Microsoft.AspNetCore.Http;
using SFA.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SFA.Site.ViewModels
{
    public class PassengerViewModels
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo {0} deve conter de {2} a {1} caracteres.")]
        public string FirstName { get; set; }

        [DisplayName("Sobrenome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo {0} deve conter de {2} a {1} caracteres.")]
        public string LastName { get; set; }

        [DisplayName("Tipo")]
        public int TypePerson { get; set; }

        [DisplayName("Passaporte")]
        public string Passport { get; set; }

        [DisplayName("Documento")]
        public string Document { get; set; }

        [DisplayName("Ativo")]
        public bool Active { get; set; }
        //public IFormFile UploadImage { get; set; }
        public string Image { get; set; }
        public IEnumerable<AddressViewModels> Addresses { get; set; }
    }
}
