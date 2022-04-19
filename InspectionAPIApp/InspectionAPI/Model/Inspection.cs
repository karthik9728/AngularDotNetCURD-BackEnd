using System.ComponentModel.DataAnnotations;

namespace InspectionAPI.Model
{
    public class Inspection
    {   
        [Key]
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int InspectionTypeId { get; set; }
        public InspectionType? InspectionType { get; set; }
    }
}
