using System.ComponentModel.DataAnnotations;

namespace InspectionAPI.Model
{
    public class InspectionType
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; } = string.Empty;
    }
}
