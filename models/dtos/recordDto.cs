using System.ComponentModel.DataAnnotations.Schema;

public class RecordDto
{
    public Guid RecordId { get; set; }
    public double ConfidenceLevel { get; set; }
    public DateTime RecordDt { get; set; }
}
