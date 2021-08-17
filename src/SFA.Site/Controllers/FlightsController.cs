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
    public class FlightsController : BaseController
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IAirplaneRepository _airplaneRepository;
        private readonly ISchedulingRepository _schedulingRepository;
        private readonly IMapper _mapper;

        public FlightsController(IFlightRepository flightRepository,
                                 IAirplaneRepository airplaneRepository,
                                 ISchedulingRepository schedulingRepository,
                                 IMapper mapper)
        {
            _flightRepository = flightRepository;
            _airplaneRepository = airplaneRepository;
            _schedulingRepository = schedulingRepository;
            _mapper = mapper;
        }

        #region Index
        public async Task<IActionResult> Index(Guid id)
        {
            return View(_mapper.Map<IEnumerable<FlightViewModels>>(await _flightRepository.GetFlightAirplane(id)));
        }
        #endregion

        #region Details
        public async Task<IActionResult> Details(Guid id)
        {
            var flightViewModels = await GetScheduling(id);

            if (flightViewModels == null) return NotFound();

            return View(flightViewModels);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FlightViewModels flightViewModels)
        {
            if (!ModelState.IsValid) return View(flightViewModels);

            await _flightRepository.Create(_mapper.Map<Flight>(flightViewModels));

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Edit
        public async Task<IActionResult> Edit(Guid id)
        {
            var flightViewModels = await GetScheduling(id);
            if (flightViewModels == null) return NotFound();

            return View(flightViewModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, FlightViewModels flightViewModels)
        {
            if (id != flightViewModels.Id) return NotFound();

            if (ModelState.IsValid) return View(flightViewModels);
            await _flightRepository.Update(_mapper.Map<Flight>(flightViewModels));

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(Guid id)
        {
            var flightViewModels = await GetScheduling(id);

            if (flightViewModels == null) return NotFound();

            return View(flightViewModels);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var flightViewModels = await GetScheduling(id);
            if (flightViewModels == null) return NotFound();

            await _flightRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        private async Task<FlightViewModels> GetScheduling(Guid id)
        {
            var scheduling = _mapper.Map<FlightViewModels>(await _flightRepository.GetFlightAirplane(id));
            scheduling.Schedules = _mapper.Map<IEnumerable<SchedulingViewModels>>(await _schedulingRepository.GetAll());

            return scheduling;
        }
    }
}
