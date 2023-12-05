﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.ViewModels
{
    public class AddJobViewModel
    {
        [Required]
        [StringLength(70, MinimumLength = 2)]
        public string Name { get; set;}

        public int EmployerId { get; set;}


        public Employer Employer { get; set;}

        public List<Employer> SelectListItem { get; set;} //instantiate?

        public AddJobViewModel(List<Employer> selectListItem)
        {
            SelectListItem = selectListItem;
        }
    }
}


