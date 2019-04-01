using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentSheet.Models
{
    public class Joker
    {
        [Required]
        [Display(Name = "Date of Incident")]
        [DataType(DataType.Date)]
        public DateTime IncidentDate { get; set; }

        [Required]
        [Display(Name = "Time of Incident")]
        [DataType(DataType.Time)]
        public DateTime IncidentTime { get; set; }
        
        [Required]
        [Display(Name = "Unit Reporting")]
        public UnitType Unit { get; set; }

        [Required]
        public string Incident { get; set; }

        [Required]
        public string Summary { get; set; }
        public int ID { get; set; }

        [Key]

        public User UserID { get; set; }

    }
}
