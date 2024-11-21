using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsApp.Data;
using ProductsApp.Models;
using ProductsApp.Services;

namespace ProductsApp.Controllers
{
    [Authorize(Roles = "employee")]
    public class ItemsController : Controller
    {
        IItemService itemService;
        IWarehouseService warehouseService;

        public ItemsController(IItemService _itemService,IWarehouseService _warehouseService)
        {
            itemService = _itemService;
            warehouseService = _warehouseService;
        }
        public IActionResult Index()
        {
            ViewData["IsEdit"] = false;
            vmItem vmItem = new vmItem();
            List<WarehouseDTO> warehouses = warehouseService.LoadAll();
            vmItem.warehouses = warehouses;
            return View("NewItem", vmItem);
        }

        public IActionResult Save(vmItem vmItem)
        {
            ViewData["IsEdit"] = false;
            itemService.Add(vmItem.item);
            return RedirectToAction("Index");
        }

        public IActionResult ItemsList()
        {
            List<ItemDTO> items= itemService.LoadAll();
            return View("ItemsList",items);
        }
        public IActionResult Delete(int id)
        {
            itemService.Delete(id);
            return RedirectToAction("ItemsList");
        }

        public IActionResult Edit(int id)
        {
            ViewData["IsEdit"] = true;
            vmItem item = new vmItem();
            ItemDTO itemDTO=itemService.Load(id);
            item.item = itemDTO;
            List<WarehouseDTO> warehouses= warehouseService.LoadAll();
            item.warehouses = warehouses;
            return View("NewItem", item);
        }

        public IActionResult Update(vmItem vmItem)
        {
            itemService.Update(vmItem.item);
            return RedirectToAction("ItemsList");
        }
    }
}
