using ProductsApp.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace ProductsApp.Models
{
    [AutoMap(typeof(City), ReverseMap = true)]
    public class CityDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Country_Id { get; set; }

        public CountryDTO Country { get; set; }
    }
}
