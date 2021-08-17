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

    public class PassengersController : BaseController
    {
        private readonly IPassengerRepository _passengerRepository;
        private readonly IMapper _mapper;

        public PassengersController(IPassengerRepository passengerRepository,
                                    IMapper mapper)
        {
            _passengerRepository = passengerRepository;
            _mapper = mapper;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<PassengerViewModels>>(await _passengerRepository.GetAll()));
        }
        #endregion

        #region Details
        public async Task<IActionResult> Details(Guid id)
        {
            var passengerViewModels = await GetPassengerAddress(id);

            if (passengerViewModels == null) return NotFound();

            return View(passengerViewModels);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PassengerViewModels passengerViewModels)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(Index));

            var passenger = _mapper.Map<Passenger>(passengerViewModels);
            await _passengerRepository.Create(passenger);

            return View(passengerViewModels);
        }
        #endregion

        #region Edit
        public async Task<IActionResult> Edit(Guid id)
        {
            var passengerViewModels = await GetPassengerAddressScheduling(id);

            if (passengerViewModels == null) return NotFound();

            return View(passengerViewModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PassengerViewModels passengerViewModels)
        {
            if (id != passengerViewModels.Id) return NotFound();
            

            if (!ModelState.IsValid) return View(passengerViewModels);

            var passenger = _mapper.Map<Passenger>(passengerViewModels);
            await _passengerRepository.Update(passenger);

            return RedirectToAction(nameof(Index));
            
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(Guid id)
        {
            var passengerViewModels = await GetPassengerAddress(id);
            if (passengerViewModels == null) return NotFound();

            return View(passengerViewModels);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var passengerViewModels = await GetPassengerAddress(id);

            if (passengerViewModels == null) return NotFound();

            await _passengerRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        private async Task<PassengerViewModels> GetPassengerAddress(Guid id)
        {
            return _mapper.Map<PassengerViewModels>(await _passengerRepository.GetPassengerAddress(id));
        }
        private async Task<PassengerViewModels> GetPassengerAddressScheduling(Guid id)
        {
            return _mapper.Map<PassengerViewModels>(await _passengerRepository.GetPassengerScheduling(id));
        }
    }
}
