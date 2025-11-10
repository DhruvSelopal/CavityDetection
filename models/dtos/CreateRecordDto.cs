namespace CavityDetection.models.dtos
{
    public class CreateRecordDto
    {
        public Guid UserId { get; set; }
        public Guid ImageId { get; set; }
        public double ConfidenceLevel { get; set; }
    }

}
