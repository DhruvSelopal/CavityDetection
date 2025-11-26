using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

[Index(nameof(Username), IsUnique = true)]   // <- goes on the class
public class UserDbo
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string Name { get; set; } = "";

    [Required]
    public string LastName { get; set; } = "";

    [Required]
    public string Username { get; set; } = "";
    [Required]
    public string Password { get; set; } = "";
    public int Age { get; set; } = 0;
    public int Height { get; set; } = 0;

    public List<RecordDbo> Records { get; set; } = new();
}
