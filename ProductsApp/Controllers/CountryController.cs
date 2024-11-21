using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsApp.Models;
using ProductsApp.Services;

namespace ProductsApp.Controllers
{
    [Authorize]
    public class CountryController : Controller
    {
        ICountryService countryService;

        public CountryController(ICountryService _countryService)
        {
            countryService = _countryService;
        }
        public IActionResult Index()
        {
            ViewData["IsEdit"] = false;
            return View("CountryForm");
        }

        public IActionResult Save(CountryDTO countryDTO)
        {
            try
            {
                countryService.Add(countryDTO);
                ViewData["result"] = "Country saved successfly";
            }
            catch
            {
                ViewData["result"] = "sorry something wrong happend";
            }
            ViewData["IsEdit"] = false;
            return View("CountryForm");
        }

        public IActionResult CountryList()
        {
            List<CountryDTO> countries=new List<CountryDTO>();
            try
            {
                countries = countryService.LoadAll();
            }
            catch
            {

            }
            return View("CountryList",countries);
        }

        public IActionResult Delete(int Id)
        {
            countryService.Delete(Id);
            return RedirectToAction("CountryList");
        }

        public IActionResult Edit(int Id)
        {
            ViewData["IsEdit"] = true;
            CountryDTO countryDTO= countryService.load(Id);
            return View("CountryForm", countryDTO);
        }
        public IActionResult Update(CountryDTO countryDTO)
        {
           
            countryService.Edit(countryDTO);
            ViewData["IsEdit"] = false;
            return RedirectToAction("CountryList");
        }
    }
}
