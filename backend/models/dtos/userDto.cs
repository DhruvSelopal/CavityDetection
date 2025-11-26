using System.ComponentModel.DataAnnotations;

public class UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Username { get; set; } = "";
    [Required]
    public string Password { get; set; } = "";
    public int Age { get; set; }
    public int Height { get; set; }

}

