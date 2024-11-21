using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsApp.Models;
using ProductsApp.Services;

namespace ProductsApp.Controllers
{
    [Authorize]
    public class CityController : Controller
    {
        ICountryService countryService;
        ICityService cityService;

        public CityController(ICountryService _countryService, ICityService _cityService)
        {
            countryService = _countryService;
            cityService = _cityService;
        }
        public IActionResult Index()
        {
            ViewData["IsEdit"] = false;
            vmCity vmCity = new vmCity();
            List<CountryDTO> countries = countryService.LoadAll();
            vmCity.countries = countries;
            return View("NewCity", vmCity);
        }

        public IActionResult Save(vmCity vmCity)
        {
            ViewData["IsEdit"] = false;
            cityService.Add(vmCity.City);
            vmCity.countries = countryService.LoadAll();
            return View("NewCity", vmCity);
        }

        public IActionResult CityList()
        {
            List<CityDTO> cities = cityService.LoadAll();
            return View("CityList", cities);
        }

        public IActionResult Delete(int id)
        {
            cityService.Delete(id);
            return RedirectToAction("CityList");
        }

        public IActionResult Edit(int Id)
        {
            ViewData["IsEdit"] = true;
            CityDTO cityDTO=cityService.Load(Id);
            vmCity vmCity=new vmCity(); 
            vmCity.City = cityDTO;
            List<CountryDTO> countries=countryService.LoadAll();
            vmCity.countries = countries;
            return View("NewCity",vmCity);
        }

        public IActionResult Update(vmCity vmCity)
        {
            cityService.update(vmCity.City);
            return RedirectToAction("CityList");
        }
    }
}
