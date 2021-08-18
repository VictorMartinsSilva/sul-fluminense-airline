using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SFA.Site.ViewModels
{
    public class AirplaneViewModels
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Modelo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string AirplaneModel { get; set; }

        [DisplayName("Número de Série")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string SerialNumber { get; set; }

        [DisplayName("Número de Passageiros")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int PassengerNumber { get; set; }

        [DisplayName("Capacidade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Capacity { get; set; }

        [DisplayName("Ativo")]
        public bool Active { get; set; }

        [HiddenInput]
        public Guid CompanyId { get; set; }
        public CompanyViewModels Company { get; set; }

        public IEnumerable<CompanyViewModels> Companies { get; set; }

        public IEnumerable<SeatViewModels> Seats { get; set; }

        public IEnumerable<FlightViewModels> Flights { get; set; }
    }
}
