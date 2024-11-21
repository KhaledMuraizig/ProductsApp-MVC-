using ProductsApp.Models;

namespace ProductsApp.Services
{
    public interface IWarehouseService
    {
        void Add(WarehouseDTO warehouseDTO);
        public List<WarehouseDTO> LoadAll();
        WarehouseDTO Load(int Id);
        public void Delete(int Id);
        void Update(WarehouseDTO warehouseDTO);
    }
}