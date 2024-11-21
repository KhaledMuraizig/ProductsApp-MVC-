namespace ProductsApp.Models
{
    public class vmAddRoleToUser
    {
        public UserDTO user { get; set; }

        public string roleName { get; set; }
        public List<RoleDTO> roles { get; set; }
    }
}
