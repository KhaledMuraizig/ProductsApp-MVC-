using AutoMapper;
using ProductsApp.Data;
using System.ComponentModel.DataAnnotations;

namespace ProductsApp.Models
{
    [AutoMap(typeof(Country), ReverseMap = true)]
    public class CountryDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
