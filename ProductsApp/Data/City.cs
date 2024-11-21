using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsApp.Data
{
    [Table("Cities")]
    public class City
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [ForeignKey("country")]
        public int Country_Id { get; set; }

        public Country country { get; set; }

        public List<Warehouse> Warehouses { get; set; }
    }
}
