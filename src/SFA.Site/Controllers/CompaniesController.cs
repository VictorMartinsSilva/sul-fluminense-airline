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
    public class CompaniesController : BaseController
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IAirplaneRepository _airplaneRepository;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyRepository companyRepository,
                                   IAirplaneRepository airplaneRepository,
                                   IMapper mapper)
        {
            _companyRepository = companyRepository;
            _airplaneRepository = airplaneRepository;
            _mapper = mapper;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<CompanyViewModels>>(await _companyRepository.GetAll()));
        }
        #endregion

        #region Details
        public async Task<IActionResult> Details(Guid id)
        {
            var companyViewModels = await GetCompanyAirplane(id);
            if (companyViewModels == null) return NotFound();

            return View(companyViewModels);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyViewModels companyViewModels)
        {
            if (!ModelState.IsValid) return View(companyViewModels);

            var company = _mapper.Map<Company>(companyViewModels);
            await _companyRepository.Create(company);

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Edit
        public async Task<IActionResult> Edit(Guid id)
        {
            var companyViewModels = await GetCompanyAirplane(id);

            if (companyViewModels == null) return NotFound();

            return View(companyViewModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CompanyViewModels companyViewModels)
        {
            if (id != companyViewModels.Id) return NotFound();

            if (!ModelState.IsValid) return View(companyViewModels);
            await _companyRepository.Update(_mapper.Map<Company>(companyViewModels));

            return  RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(Guid id)
        {
            var company = await GetCompanyAirplane(id);

            if (company == null) return NotFound();

            return View(company);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var company = await GetCompanyAirplane(id);

            if (company == null) return NotFound();

            await _companyRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
        #endregion

        private async Task<CompanyViewModels> GetCompanyAirplane(Guid id)
        {
            return _mapper.Map<CompanyViewModels>(await _companyRepository.GetCompanyAirplane(id));
        }
        
         private async Task<CompanyViewModels> GetCompanyAirplanes(Guid id)
        {
            var company = _mapper.Map<CompanyViewModels>(await _companyRepository.GetCompanyAirplane(id));
            company.Airplanes = _mapper.Map<IEnumerable<AirplaneViewModels>>(await _airplaneRepository.GetAll());

            return company;
        }
    }
}
