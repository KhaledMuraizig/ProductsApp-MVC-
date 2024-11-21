using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsApp.Models;
using ProductsApp.Services;

namespace ProductsApp.Controllers
{
    [Authorize(Roles = "manager")]
    public class WarehouseController : Controller
    {
        IWarehouseService warehouseService;
        ICountryService countryService;
        ICityService cityService;

        public WarehouseController(IWarehouseService _warehouseService, ICountryService _countryService, ICityService _cityService)
        {
            warehouseService = _warehouseService;
            countryService = _countryService;
            cityService = _cityService;
        }
        public IActionResult Index()
        {
            ViewData["IsEdit"] = false;
            vmWarehouse vmWarehouse = new vmWarehouse();
            List<CountryDTO> countries = countryService.LoadAll();
            List<CityDTO> cities = cityService.LoadAll();
            vmWarehouse.cities = cities;
            vmWarehouse.countries = countries;
            return View("NewWarehouse", vmWarehouse);
        }

        public IActionResult Save(vmWarehouse vmWarehouse)
        {
            ViewData["IsEdit"] = false;
            warehouseService.Add(vmWarehouse.warehouse);
            return RedirectToAction("Index");
        }

        public IActionResult WarehouseList()
        {
            List<WarehouseDTO> warehouses = warehouseService.LoadAll();
            return View("WarehouseList", warehouses);
        }

        public IActionResult Delete(int id)
        {
            warehouseService.Delete(id);
            return RedirectToAction("WarehouseList");
        }

        public IActionResult Edit(int Id)
        {
            ViewData["IsEdit"] = true;
            WarehouseDTO warehouse=warehouseService.Load(Id);
            List<CountryDTO> countries=countryService.LoadAll();
            List<CityDTO> cities=cityService.LoadAll();
            vmWarehouse vmWarehouse=new vmWarehouse();
            vmWarehouse.warehouse = warehouse;
            vmWarehouse.countries= countries;
            vmWarehouse.cities= cities;
            return View("NewWarehouse",vmWarehouse);
        }

        public IActionResult Update(vmWarehouse vmWarehouse)
        {
            warehouseService.Update(vmWarehouse.warehouse);
            return RedirectToAction("WarehouseList");
        }
    }
}
