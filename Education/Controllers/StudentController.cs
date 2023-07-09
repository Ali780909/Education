
using EducationModel;
using Microsoft.AspNetCore.Mvc;

namespace Education 
{
    public class StudentController : Controller
    {
        Context dbcontext;
        public StudentController(Context _dbContext)
        {
            dbcontext = _dbContext;
        }

        public IActionResult Get(int id)
        {
            var student = dbcontext.students.FirstOrDefault(i => i.Student_ID == id);
            if (student != null)
            {
             
                return View(student);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var students = dbcontext.students.ToList();
            return View(students);
        }


        [HttpGet]
        public IActionResult Delete(Student student)
        {
            dbcontext.students.Remove(student);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
