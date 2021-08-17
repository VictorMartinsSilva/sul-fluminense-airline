using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SFA.Business.Interfaces;
using SFA.Business.Models;
using SFA.Site.ViewModels;

namespace SFA.Site.Controllers
{
    public class AirplanesController : BaseController
    {
        private readonly IAirplaneRepository _airplaneRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IFlightRepository _fligthRepository;
        private readonly IMapper _mapper;

        public AirplanesController(IAirplaneRepository airplaneRepository,
                                    ICompanyRepository companyRepository,
                                    IFlightRepository fligthRepository,
                                    ISeatRepository seatRepository,
                                    IMapper mapper)
        {
            _airplaneRepository = airplaneRepository;
            _companyRepository = companyRepository;
            _fligthRepository = fligthRepository;
            _seatRepository = seatRepository;
            _mapper = mapper;
        }

        #region Index
        public async Task<IActionResult> Index(Guid id)
        {
            return View(_mapper.Map<IEnumerable<AirplaneViewModels>>(await _airplaneRepository.GetAirplaneCompany(id)));
        }
        #endregion

        #region Details
        public async Task<IActionResult> Details(Guid id)
        {
            var airplaneViewModels = await GetAirplane(id);

            if (airplaneViewModels == null) return NotFound();

            return View(airplaneViewModels);
        }
        #endregion

        #region Create
        public async Task<IActionResult> Create()
        {
            var airplaneViewModels = await FindSeatsFlights(new AirplaneViewModels());

            return View(airplaneViewModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AirplaneViewModels airplaneViewModels)
        {
            airplaneViewModels = await FindSeatsFlights(airplaneViewModels);
            if (!ModelState.IsValid) return View(airplaneViewModels);

            await _airplaneRepository.Create(_mapper.Map<Airplane>(airplaneViewModels));

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Edit
        public async Task<IActionResult> Edit(Guid id)
        {
            var airplaneViewModels = await GetAirplane(id);
            if (airplaneViewModels == null) return NotFound();
            
            return View(airplaneViewModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AirplaneViewModels airplaneViewModels)
        {
            if (id != airplaneViewModels.Id) return NotFound();

            if (!ModelState.IsValid) return RedirectToAction(nameof(Index));
            await _airplaneRepository.Update(_mapper.Map<Airplane>(airplaneViewModels));

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(Guid id)
        {
            var airplaneViewModels = GetAirplane(id);
            if (airplaneViewModels == null) return NotFound();

            return View(airplaneViewModels);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var airplaneViewModels = GetAirplane(id);
            if (airplaneViewModels == null) return NotFound();

            await _airplaneRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        private async Task<AirplaneViewModels> GetAirplane(Guid id)
        {
            var airplane = _mapper.Map<AirplaneViewModels>(await _airplaneRepository.GetAirplaneCompany(id));
            airplane.Seats = _mapper.Map<IEnumerable<SeatViewModels>>(await _seatRepository.GetAll());
            airplane.Flights = _mapper.Map<IEnumerable<FlightViewModels>>(await _fligthRepository.GetAll());

            return airplane;
        }

        private async Task<AirplaneViewModels> FindSeatsFlights(AirplaneViewModels airplane)
        {
            airplane.Seats = _mapper.Map<IEnumerable<SeatViewModels>>(await _seatRepository.GetAll());
            airplane.Flights = _mapper.Map<IEnumerable<FlightViewModels>>(await _fligthRepository.GetAll());

            return airplane;
        }
    }
}
