using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductsApp.Data;
using ProductsApp.Models;

namespace ProductsApp.Services
{
    public class CountryService: ICountryService
    {
        ProductsContext context;
        private readonly IMapper mapper;

        public CountryService(ProductsContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public void Add(CountryDTO countryDTO)
        {
            Country country = mapper.Map<Country>(countryDTO);
            context.Countries.Add(country);
            context.SaveChanges();
        }

        public List<CountryDTO> LoadAll()
        {
            List<Country> countries = context.Countries.ToList();
            List<CountryDTO> countriesDTO =mapper.Map<List<CountryDTO>>(countries);
            return countriesDTO;
        }

        public void Delete(int Id)
        {
            Country country=context.Countries.Find(Id);
            context.Countries.Remove(country);
            context.SaveChanges();
        }

        public CountryDTO load(int Id)
        {
            Country country = context.Countries.Find(Id);
            CountryDTO countryDTO =mapper.Map<CountryDTO>(country);
            return countryDTO;
        }

        public void Edit(CountryDTO countryDTO)
        {
            Country country=mapper.Map<Country>(countryDTO);
            context.Countries.Attach(country);
            context.Entry(country).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
