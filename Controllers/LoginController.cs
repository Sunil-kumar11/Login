﻿using Login.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public List<Student> PutValues()
        {
            var Students =new List<Student> { 
            new Student
            {
                Id=121,
                UserName = "raju",
                Password = "Raju@123"
            },
            new Student
            {
                Id=122,
                UserName = "suresh",
                Password = "suresh@123"
            },
            new Student
            {
                Id=123,
                UserName = "vikas",
                Password = "vikas@123"
            },
            new Student
            {
                Id=124,
                UserName = "mahesh",
                Password = "mahesh@123"
            }
          };
            return Students;
        }

        public IActionResult LoginUser(Student student)
        {
            var Students = PutValues();
            var name = Students.Where( x => x.UserName.Equals(student.UserName));
            var pswd = Students.Where( x => x.Password.Equals(student.Password));

            if(name.Count()==1 && pswd.Count() == 1)
            {
                ViewBag.message = "Login Success";
                return View("Login");
            }
            else
            {
                ViewBag.message = "UserName Or Password is Wrong please enter correct UserName And Password";
                return View("Login");
            }
        }
    }
}