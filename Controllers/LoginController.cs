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
        static List<Student> Students = new List<Student>();


        public IActionResult Index()
        {
            return View(Students);
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Delete(int id)
        {

            var stdD = Students.Where(s => s.Id == id).FirstOrDefault();
            
            return View(stdD);
        }
        [HttpPost]
        public ActionResult Delete(Student stdD)
        {
            var student = Students.Where(s => s.Id == stdD.Id).FirstOrDefault();
            Students.Remove(student);
            return View("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int Id)
        {
            var std = Students.Where(s => s.Id == Id).FirstOrDefault();


            return View(std);
        }



        [HttpPost]
        public IActionResult Create(Student student)
        {
            int num = Students.Count;
            Students.Add(student);
            if (Students.Count > num)
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
        [HttpPost]
        //[Route("api/[controller]/{action}/{Id}")]
        public ActionResult Edit(Student std)
        {

            //var username = student.UserName;
            //var password = student.Password;
            //var std = student;

            //return View("Index");


            var student = Students.Where(s => s.Id == std.Id).FirstOrDefault();
            Students.Remove(student);
            Students.Add(std);

            return RedirectToAction("Index");
            //if (std != null)
            //{
            //    Students.Add(std);
            //    ViewBag.message = "User details added";
            //    return View("Index");

            //}
            //else
            //{
            //    ViewBag.message1 = "UserName Or Password is Wrong please enter correct UserName And Password";
            //    return View("Create");
            //}
        }
        public List<Student> PutValues()
        {
            
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

            //[HttpDelete("{id}")]

            //public ActionResult Delete(int id)
            //{
            //    Student friend = Students.Find(f => f.Id == id);
            //    Students.Remove(friend);
            //    return View("Index");
            //}




        }   

    }
    
}
