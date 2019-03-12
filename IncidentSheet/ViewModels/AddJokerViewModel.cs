using IncidentSheet.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentSheet.ViewModels
{

    public class AddJokerViewModel
    {
        [Required]
        [Display(Name = "Date of Incident")]
        public DateTime IncidentDate { get; set; }

        [Required]
        [Display(Name = "Time of Incident")]
        public DateTime IncidentTime { get; set; }


        public AddJokerViewModel()
        {
            string[] enumUnitTypes = Enum.GetNames(typeof(UnitType));
            List<string> unit = new List<string>(enumUnitTypes);
        }

        /* [Required(ErrorMessage ="You must enter a Unit reporting the Incident")]*/
        [Display(Name = "Unit reporting Incident")]
        public UnitType Unit { get; set; }


        /*[Required(ErrorMessage = "Must identify the incident which occurred")]*/
        [Display(Name = "Type of Crime(s)")]
        public string Incident { get; set; }

        /*[Required(ErrorMessage = "Must enter a summary of the Incident*/
        [Display(Name = "Summary of the Incident")]
        public string Summary { get; set; }
    }
}
