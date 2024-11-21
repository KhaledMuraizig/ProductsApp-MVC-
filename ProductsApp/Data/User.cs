using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsApp.Data
{
    [Table("Users")]
    public class User:IdentityUser
    {

        [StringLength(50)]
        public string  FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }
    }
}
