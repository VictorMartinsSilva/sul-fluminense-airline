using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SFA.Site.ViewModels
{
    public class CompanyViewModels
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O campo {0} deve conter {1} caracteres.")]
        public string CNPJ { get; set; }

        [DisplayName("Ativo")]
        public bool Active { get; set; }

        public IEnumerable<AirplaneViewModels> Airplanes { get; set; }
    }
}
