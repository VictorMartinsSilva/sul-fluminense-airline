using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SFA.Site.ViewModels
{
    public class SeatViewModels
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Número do Assento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Number { get; set; }

        [DisplayName("Classe")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string TypeClass { get; set; }

        [HiddenInput]
        public Guid AirplaneId { get; set; }
        public AirplaneViewModels Airplane { get; set; }
        public IEnumerable<SchedulingViewModels> Schedules { get; set; }
    }
}
