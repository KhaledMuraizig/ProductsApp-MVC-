using ProductsApp.Models;

namespace ProductsApp.Services
{
    public interface ICountryService
    {
        void Add(CountryDTO countryDTO);
        List<CountryDTO> LoadAll();
        void Delete(int Id);
        CountryDTO load(int Id);
        void Edit(CountryDTO countryDTO);
    }
}