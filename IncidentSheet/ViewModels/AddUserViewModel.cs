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
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        [Required]
        [Display(Name = "Verify Password")]
        [DataType(DataType.Password)]
        [Compare("UserPassword", ErrorMessage = "The password and conformation password do not match")]
        public string VerifyPassword { get; set; }

        private string Role { get; set; }

    }
}
