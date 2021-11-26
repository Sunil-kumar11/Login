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
        

        public IActionResult Index()
        {
            var std = PutValues();
            return View(std);
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            int num = PutValues().Count;
            PutValues().Add(student);
            if (PutValues().Count != num)
            {
                ViewBag.message = "student details added successfully";

                return View("Create");
            }
            else
            {
                ViewBag.message = "student details added failed";

                return View("Create");
            }
        }
        public ActionResult Edit(int Id)
        {
            var students = PutValues();
            var std = students.Where(s => s.Id == Id).FirstOrDefault();

            return View(std);
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
        [Route("api/[controller]/{action}")]
        public IActionResult Login(Student student)
        {

           

            var Students = PutValues();

            var obj = Students.Where(a => a.UserName.Equals(student.UserName) && a.Password.Equals(student.Password)).FirstOrDefault();
            if (obj != null)
            {
                ViewBag.message = "Login success";
                return View("Login");

            }
            else
            {
                ViewBag.message1 = "UserName Or Password is Wrong please enter correct UserName And Password";
                return View("Login");
            }





            //string s = student.UserName;
            //string pswd = student.Password;
            //var name = Students.Where(x => x.UserName.Equals(student.UserName);
            //var m = Students.SingleOrDefault(x => x.Password == student.Password);
            //for (int i = 0; i < Students.Count ; i++)
            //{
            //    if (s == Students[i].UserName && pswd == Students[i].Password && Students[i].Id == Students[i].Id)
            //   
            //}

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
            //public IActionResult PostStudents(Student student)
            //{
        }
    }
}
