using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspections.Model.Model
{
    public class InspectionType
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string InspectionName { get; set; } = string.Empty;
    }
}
