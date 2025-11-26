using System.ComponentModel.DataAnnotations;

namespace CavityDetection.models.dtos
{
    public class UserUpdate
    {
        [Required]
        public string username { get; set; } = "";
        public string Name { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Age { get; set; }
        public int Height { get; set; }
    }
}
