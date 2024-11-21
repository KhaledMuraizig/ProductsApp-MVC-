using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductsApp.Data;
using ProductsApp.Models;

namespace ProductsApp.Services
{
    public class WarehouseService : IWarehouseService
    {
        ProductsContext context;
        IMapper mapper;

        public WarehouseService(ProductsContext _context, IMapper mapper)
        {
            context = _context;
            this.mapper = mapper;
        }

        public void Add(WarehouseDTO warehouseDTO)
        {
            Warehouse warehouse=mapper.Map<Warehouse>(warehouseDTO);
            context.Warehouses.Add(warehouse);
            context.SaveChanges();
        }

        public List<WarehouseDTO> LoadAll()
        {
            List<Warehouse> warehouses=context.Warehouses.Include("City").Include("Country").ToList();
            List<WarehouseDTO> warehouseDTOs=mapper.Map<List<WarehouseDTO>>(warehouses);
            return warehouseDTOs;
        }

        public WarehouseDTO Load(int Id)
        {
            Warehouse warehouse = context.Warehouses.Find(Id);
            WarehouseDTO warehouseDTO=mapper.Map<WarehouseDTO>(warehouse);
            return warehouseDTO;
        }

        public void Delete(int Id)
        {
            Warehouse warehouse=context.Warehouses.Find(Id);
            context.Warehouses.Remove(warehouse);
            context.SaveChanges();
        }

        public void Update(WarehouseDTO warehouseDTO)
        {
            Warehouse warehouse = mapper.Map<Warehouse>(warehouseDTO);
            context.Warehouses.Attach(warehouse);
            context.Entry(warehouse).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
