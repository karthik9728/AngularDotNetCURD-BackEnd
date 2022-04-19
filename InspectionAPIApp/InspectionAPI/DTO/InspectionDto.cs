namespace InspectionAPI.DTO
{
    public class InspectionDto
    {
        public string Status { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int InspectionTypeId { get; set; }
    }
}
