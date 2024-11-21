namespace ProductsApp.Models
{
    public class vmItem
    {
        public ItemDTO item { get; set; }
        public List<WarehouseDTO> warehouses { get; set; }
    }
}
