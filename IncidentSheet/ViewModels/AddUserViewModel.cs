using IncidentSheet.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace IncidentSheet.ViewModels
{
    public class AddUserViewModel
    {
        [Required]
        [Display(Name = "User's Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "User's Password")]
        public string UserPassword { get; set; }

        public int UserId { get; set; }

    }
}
