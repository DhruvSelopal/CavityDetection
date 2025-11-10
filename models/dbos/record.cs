using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RecordDbo
{
    [Key]
    public Guid RecordId { get; set; } = Guid.NewGuid();
    [Required]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbo User { get; set; }
    [Required]
    public Guid ImageId { get; set; }
    [Required]
    public double ConfidenceLevel { get; set; }
    [Required]
    public DateTime RecordDt { get; set; } = DateTime.UtcNow;
}
