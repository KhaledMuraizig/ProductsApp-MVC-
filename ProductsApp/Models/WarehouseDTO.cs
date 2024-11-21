using AutoMapper;
using ProductsApp.Data;
using System.ComponentModel.DataAnnotations;

namespace ProductsApp.Models
{
    [AutoMap(typeof(Warehouse),ReverseMap = true)]
    public class WarehouseDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Country_Id { get; set; }
        public int City_Id { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
    }
}
