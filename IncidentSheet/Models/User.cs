using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentSheet.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string VerifyPassword { get; set; }
        private string Role { get; set; }
        public int ID { get; set; }

        public IList<Joker> Jokers { get; set; }

    }
}
