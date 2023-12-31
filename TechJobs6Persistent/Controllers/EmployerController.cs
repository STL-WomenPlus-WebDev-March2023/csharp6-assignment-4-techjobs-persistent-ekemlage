﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using TechJobs6Persistent.Data;
using TechJobs6Persistent.Models;
using TechJobs6Persistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobs6Persistent.Controllers
{
    public class EmployerController : Controller
    {
        private JobDbContext context;
  
        public EmployerController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            List<Employer> employers = context.Employers.ToList();
            return View(employers); 
        }

        [HttpGet]
        public IActionResult Add() // method previously "Create" (also renamed views>employer>create to be add)
        {
            AddEmployerViewModel addEmployerViewModel= new AddEmployerViewModel();
            return View(addEmployerViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEmployerViewModel addEmployerViewModel)  // method previously "ProcessCreateEmployerForm"  renamed to add
        {
            if (ModelState.IsValid)
            {
                Employer newEmployer = new Employer 
                { 
                    Name = addEmployerViewModel.Name, 
                    Location = addEmployerViewModel.Location
                };
                context.Employers.Add(newEmployer);
                context.SaveChanges();
                return View(); 
            }
            return View(addEmployerViewModel);
        }
            
        
        public IActionResult About(int id)
        {
            Employer? employerFoundById = context.Employers.Find(id);
            return View(employerFoundById);
        }



    }
}

