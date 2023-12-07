using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobs6Persistent.Models;
using TechJobs6Persistent.Data;

namespace TechJobs6Persistent.ViewModels
{
    public class AddJobViewModel
    {
        [Required]
        [StringLength(70, MinimumLength = 2)]
        public string Name { get; set;}

        [Required]
        public int EmployerId { get; set;}


        public Employer? Employer { get; set;}


        public List<Employer>? Employers { get; set;}

        public List<SelectListItem>? SelectListItems { get; set; }
        /*
        public AddJobViewModel(List<Employer> selectListItem)
        {
            SelectListItem = selectListItem;
        }
        */

        /*

        public AddJobViewModel(List<Employer> employers)
        {
            List<SelectListItem> Employers = new List<SelectListItem>();

            foreach (var employer in employers)                                    //old version, from last night
            {
                Employers.Add(new SelectListItem
                {
                    Name = employer.Name.ToString(),
                    Location = employer.Location.ToString
                });
            }
        }

        */


        public AddJobViewModel(List<Employer> employers)
        {
            SelectListItems = new List<SelectListItem>();

            foreach (var employer in employers)
            {
                SelectListItems.Add(new SelectListItem           //new version
                {
                    Text = employer.Name,
                    Value = employer.Id.ToString()
                });
            }
        }

        public AddJobViewModel()
        {
           
        }



    }
}



