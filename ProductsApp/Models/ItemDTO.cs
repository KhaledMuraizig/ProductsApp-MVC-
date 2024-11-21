using ProductsApp.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace ProductsApp.Models
{
    [AutoMap(typeof(Item),ReverseMap = true)]
    public class ItemDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? KU_Code { get; set; }

        public int Qty { get; set; }

        public double CostPrice { get; set; }
        public double? MSRP_Price { get; set; }

        [Required]
        public int Warehouse_Id { get; set; }

        public Warehouse Warehouse { get; set; }
    }
}
