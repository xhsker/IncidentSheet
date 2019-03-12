using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentSheet.Models
{
    public class Joker
    {
        public DateTime IncidentDate { get; set; }
        public DateTime IncidentTime { get; set; }
        public UnitType Unit { get; set; }
        public string Incident { get; set; }
        public string Summary { get; set; }
        public int ID { get; set; }

        public IList<User> Users { get; set; }
    }

}
