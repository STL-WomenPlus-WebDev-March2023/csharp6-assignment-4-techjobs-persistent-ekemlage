using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TechJobs6Persistent.Data;
using TechJobs6Persistent.Models;
using TechJobs6Persistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobs6Persistent.Controllers
{
    public class JobController : Controller
    {
        private JobDbContext context;

        public JobController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.Include(j => j.Employer).ToList();

            return View(jobs);
        }

        /*

        [HttpGet] //added httpget
        public IActionResult Add() //added argument (prev none)
        {
            AddJobViewModel addJobViewModel = new AddJobViewModel(context.Employers.ToList()); //old from last night
            //AddJobViewModel addJobViewModel = new AddJobViewModel();
            return View(addJobViewModel);
        }

        */

        /*

        [HttpPost]
        public IActionResult Add(AddJobViewModel addJobViewModel)
        {

            if (ModelState.IsValid)
            {
                Job newJob = new Job
                {
                    Name = addJobViewModel.Name,
                    Employer = addJobViewModel.Employer,                  //old from last night
                    EmployerId = addJobViewModel.Employer.Id,
                };
                context.Jobs.Add(newJob);
                context.SaveChanges();
                return RedirectToAction("Add");
            }

            return View(addJobViewModel);
        }

        */

        public IActionResult Add()
        {
            List<Employer> employers = context.Employers.ToList();
            AddJobViewModel addJobViewModel = new AddJobViewModel(employers);  //new from today

            return View(addJobViewModel);
        }


        [HttpPost]
        public IActionResult Add(AddJobViewModel addJobViewModel)
        {
            if (ModelState.IsValid)
            {
                Employer theEmployer = context.Employers.Find(addJobViewModel.EmployerId);
                Job newJob = new Job
                {
                    Name = addJobViewModel.Name,
                    Employer = theEmployer
                };

                context.Jobs.Add(newJob);
                context.SaveChanges();

                return Redirect("Index"); 
            }

            return View(addJobViewModel);
        }

        /* last jamey saw:
        [HttpPost]
        public IActionResult Add(AddJobViewModel addJobViewModel)
        {
            if (ModelState.IsValid)
            {
                Employer newEmployer = new Employer
                {
                    Name = addJobViewModel.Employer.Name,
                                                            //new tonight from book
                    Id = addJobViewModel.Employer.Id,
                };

                context.Employers.Add(newEmployer);
                context.SaveChanges();

                return View(addJobViewModel); //idk
            }

            return View(addJobViewModel);
        }
        */



        public IActionResult Delete()
        {
            ViewBag.jobs = context.Jobs.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] jobIds)
        {
            foreach (int jobId in jobIds)
            {
                Job theJob = context.Jobs.Find(jobId);
                context.Jobs.Remove(theJob);
            }

            context.SaveChanges();

            return Redirect("/Job");
        }

        public IActionResult Detail(int id)
        {
            Job theJob = context.Jobs.Include(j => j.Employer).Include(j => j.Skills).Single(j => j.Id == id);

            JobDetailViewModel jobDetailViewModel = new JobDetailViewModel(theJob);

            return View(jobDetailViewModel);

        }
    }
}

