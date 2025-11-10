using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ImageDbo
{
    [Key]
    public Guid ImageId { get; set; } = Guid.NewGuid();

    public TimeOnly Time { get; set; } = TimeOnly.FromDateTime(DateTime.Now);

    [Required]
    public string FilePath { get; set; } = "";  // fixed missing `= ""`
}