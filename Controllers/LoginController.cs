using Login.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
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
        public IActionResult Create()
        {
            return View("Create");
        }
        public List<Student> PutValues()
        {
            
        
            
            List<Student> Students =new List<Student> { 
            new Student
            {
                Id=121,
                UserName = "Raju",
                Password = "Raju@123"
            },
            new Student
            {
                Id=124,
                UserName = "raju",
                Password = "Raju@456"
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

        [HttpPost]
        public IActionResult LoginUser(Student student)
        {

            string s = student.UserName;
            string pswd = student.Password;
            var Students = PutValues();
            for (int i = 0; i < Students.Count - 1; i++)
            {
                if (s == Students[i].UserName && pswd == Students[i].Password && Students[i].Id == Students[i].Id)
                {
                    ViewBag.message = "Login Success";
                    return View("Login");
                }
            }
                ViewBag.message1 = "UserName Or Password is Wrong please enter correct UserName And Password";
                return View("Login");

        }

        


        //var name = Students.Where(x => x.UserName.Equals(student.UserName));
        //var pswd = name.Where(x => x.Password.Equals(student.Password));


        //if (name.Count()>= 1)
        //{
        //    ViewBag.message = "Login Success";
        //    return View("Login");
        //}
        //else
        //{
        //    ViewBag.message1 = "UserName Or Password is Wrong please enter correct UserName And Password";
        //    return View("Login");
        //}


        [HttpPost]
        public IActionResult PostStudents(Student student)
        {

            PutValues().Add(student);
            ViewBag.message = "student details added successfully";
            return View("Create");
                   }
    }
}
