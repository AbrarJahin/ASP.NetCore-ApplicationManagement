﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                context.Teacher.Add(new DbModel.Teacher
                {
                    NickName = "C",
                    DateOfbirth = DateTime.Now
                });
                context.SaveChangesAsync();
            }

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
