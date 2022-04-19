namespace InspectionAPI.DTO
{
    public class UpdateInspectionDto
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int InspectionTypeId { get; set; }
    }
}
