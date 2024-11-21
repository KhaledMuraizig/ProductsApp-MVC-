using ProductsApp.Models;

namespace ProductsApp.Services
{
    public interface ICityService
    {
        void Add(CityDTO cityDTO);
        List<CityDTO> LoadAll();
        void Delete(int Id);

        CityDTO Load(int Id);
        void update(CityDTO cityDTO);
    }
}