using ProductsApp.Models;

namespace ProductsApp.Services
{
    public interface IItemService
    {
        void Add(ItemDTO itemDTO);
        List<ItemDTO> LoadAll();
        void Delete(int Id);
        ItemDTO Load(int Id);
        void Update(ItemDTO itemDTO);
    }
}