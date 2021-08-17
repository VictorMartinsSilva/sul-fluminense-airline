using Microsoft.AspNetCore.Mvc;
using SFA.Site.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SFA.Site.ViewModels
{
    public class SchedulingViewModels
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Bagagem de Mão")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int HandBaggage { get; set; }

        [DisplayName("Bagagem de Despacho")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int CheckedBaggage { get; set; }

        [Moeda]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public decimal Price { get; set; }


        [HiddenInput]
        public Guid FlightId { get; set; }
        public FlightViewModels Flights { get; set; }

        [HiddenInput]
        public Guid SeatId { get; set; }
        public SeatViewModels Seats { get; set; }
    }
}
