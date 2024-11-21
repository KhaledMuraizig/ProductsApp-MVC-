using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsApp.Data
{
    [Table("countries")]
    public class Country
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public List<City> Cities { get; set; }

        public List<Warehouse> Warehouses { get; set; }
    }
}
