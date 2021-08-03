using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SFA.Site.ViewModels
{
    public class FlightViewModels
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Origem")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo {0} deve conter de {2} a {1} caracteres.")]
        public string Origin { get; set; }

        [DisplayName("Destino")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo {0} deve conter de {2} a {1} caracteres.")]
        public string Destiny { get; set; }

        [DisplayName("Data de Partida")]
        [ScaffoldColumn(false)]
        public DateTime DepartureDate { get; set; }

        [DisplayName("Data de Chegada")]
        [ScaffoldColumn(false)]
        public DateTime ArrivalDate { get; set; }

        [DisplayName("Ativo")]
        public bool Active { get; set; }

        [HiddenInput]
        public Guid AirPlaneId { get; set; }
        public AirplaneViewModels AirPlanes { get; set; }
        public IEnumerable<SchedulingViewModels> Schedules { get; set; }
    }
}
