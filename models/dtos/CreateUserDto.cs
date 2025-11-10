namespace CavityDetection.models.dtos
{
    public class CreateUserDto
    {
        public string Name { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Username { get; set; } = "";
        public string Passworded { get; set; } = "";
        public int Age { get; set; }
        public int Height { get; set; }
    }

}
