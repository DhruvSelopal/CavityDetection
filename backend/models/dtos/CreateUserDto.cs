using System.ComponentModel.DataAnnotations;

namespace CavityDetection.models.dtos
{
    public class CreateUserDto
    {
        public string Name { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Username { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
        public int Age { get; set; }
        public int Height { get; set; }
    }

}
