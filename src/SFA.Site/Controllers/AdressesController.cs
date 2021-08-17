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
    public class AdressesController : BaseController
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AdressesController(IAddressRepository addressRepository,
                                  IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<AddressViewModels>>(await _addressRepository.GetAll()));
        }
        #endregion

        #region Details
        public async Task<IActionResult> Details(Guid id)
        {
            var addressViewModels = await GetAddressPassenger(id);

            if (addressViewModels == null) return NotFound();

            return View(addressViewModels);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddressViewModels addressViewModels)
        {
            if (!ModelState.IsValid) return View(addressViewModels);

            var address = _mapper.Map<Address>(addressViewModels);
            await _addressRepository.Create(address);

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Edit
        public async Task<IActionResult> Edit(Guid id)
        {
            var addressViewModels = await GetAddressPassenger(id);
            if (addressViewModels == null) return NotFound();

            return View(addressViewModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AddressViewModels addressViewModels)
        {
            if (id != addressViewModels.Id) return NotFound();

            if (!ModelState.IsValid) return View(addressViewModels);

            var address = _mapper.Map<Address>(addressViewModels);
            await _addressRepository.Update(address);

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(Guid id)
        {
            var addressViewModels = await GetAddressPassenger(id);

            if (addressViewModels == null) return NotFound();

            return View(addressViewModels);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var addressViewModels = await GetAddressPassenger(id);

            if (addressViewModels == null) return NotFound();

            await _addressRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
        #endregion

        private async Task<AddressViewModels> GetAddressPassenger(Guid id)
        {
            return _mapper.Map<AddressViewModels>(await _addressRepository.GetAddressPassenger(id));
        }
    }
}
