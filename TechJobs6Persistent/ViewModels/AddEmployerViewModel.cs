using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.ViewModels
{
    public class AddEmployerViewModel
    {
        [Required]
        [StringLength(70, MinimumLength = 2)]
        public string? Name { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string? Location { get; set; }
    }
}



