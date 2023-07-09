using EducationModel;
using Microsoft.AspNetCore.Mvc;

namespace Education 
{
    public class TeacherController : Controller
    {
        Context dbcontext;
        public TeacherController(Context _dbContext)
        {
            dbcontext = _dbContext;
        }

        public IActionResult Index()
        {
            var teachers = dbcontext.students.ToList();
            return View(teachers);
        }


        [HttpGet]
        public IActionResult Delete(Teacher teacher)
        {
            dbcontext.teachers.Remove(teacher);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
