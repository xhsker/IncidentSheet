using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentSheet.Models
{
    public class Joker
    {
        [DataType(DataType.Date)]
        public DateTime IncidentDate { get; set; }
        [DataType(DataType.Time)]
        public DateTime IncidentTime { get; set; }
        public UnitType Unit { get; set; }
        public string Incident { get; set; }
        public string Summary { get; set; }
        public int ID { get; set; }

        [Key]

        public User UserID { get; set; }

    }
}
