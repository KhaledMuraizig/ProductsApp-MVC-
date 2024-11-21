using System.ComponentModel.DataAnnotations;

namespace ProductsApp.Models
{
    public class RoleDTO
    {
        public string RoleId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
