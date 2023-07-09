using EducationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace Education 
{
    public class TrainerController : Controller
    {
        Context dbcontext;
        public TrainerController(Context _dbContext)
        {
            dbcontext = _dbContext;
        }

        public IActionResult Get(int id)
        {
            var trainer = dbcontext.trainers.FirstOrDefault(i => i.Trainer_ID == id);
            if (trainer != null)
            {

                return View(trainer);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var trainers = dbcontext.students.ToList();
            return View(trainers);
        }

        [HttpGet]
        public IActionResult GetProjects()
        {

            List<Project> listOfProjects = new List<Project>();
            {
                ViewBag.projects = dbcontext.projects.Select(i => new SelectListItem(i.Project_Name, i.Project_Link.ToString()));

                return View(listOfProjects);
            }

        }
        [HttpPost]
        public IActionResult GetGrades(StudentModel grade)
        {

            if (ModelState.IsValid == false)
            {
                var errors =
                    ModelState.SelectMany(i => i.Value.Errors.Select(x => x.ErrorMessage));

                foreach (string err in errors)
                    ModelState.AddModelError("", err);
                ViewBag.Success = false;
                return View();
            }
            else
            {
                Student studentgrade = new Student
                {
                    Student_ID = grade.Student_ID,
                    Student_Name = grade.Student_Name,
                   
                    
                };
                dbcontext.students.Add(studentgrade);
                dbcontext.SaveChanges();
                ViewBag.Success = true;
                return View();
            }

        }
        [HttpGet]
        public IActionResult Edit(int grade)
        {
            ViewBag.Title = "Edit Grade";
            
            Student student = dbcontext.students.FirstOrDefault(i => i.Student_ID == grade);
            StudentModel studentModel = new StudentModel
            {
            
                Student_ID = student.Student_ID
                
            };
            return View(studentModel);
        }

        [HttpPost]
        public IActionResult Edit(StudentModel studentgrade)
        {
            Student studentOfGrade = dbcontext.students.FirstOrDefault(i => i.Student_ID == studentgrade.Student_ID);
            studentgrade.Student_Name = studentgrade.Student_Name;
             
            dbcontext.students.Update(studentOfGrade);
            dbcontext.SaveChanges();
            return RedirectToAction("AllStudent");
        }

    }
}
