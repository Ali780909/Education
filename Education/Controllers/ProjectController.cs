using Education.Models;
using EducationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace Education 
{
    public class ProjectController : Controller
    {
        Context dbcontext;
        //private IConfiguration con;

        public ProjectController(Context _dbContext)
        {
            dbcontext = _dbContext;
        }

        //public ProjectController(IConfiguration _con)
        //{

        //    con = _con;
        //}
        public IActionResult Get(int id)
        {
            //var project = dbcontext.projects.FirstOrDefault(i => i.Project_ID == id);
            //if (project != null)
            //{
            //    ViewBag.Project_Name = con.GetSection("Project_Name").Value.ToString();
            //    ViewBag.Project_Link = con.GetSection("Project_Link").Value.ToString();
            //    return View(project);
            //}
            //return RedirectToAction("Index");
            var Project = dbcontext.projects.ToList();
            return View(Project);
        }

        public IActionResult Index(int pageIndex = 1, int pageSize = 3)
        {
            ViewBag.Title = "Project  | Index";
            //var projects = dbcontext.projects.ToPagedList(pageIndex, pageSize);

            //ViewBag.Project_Name = con.GetSection("Project_Name").Value.ToString();
            //ViewBag.Project_Link = con.GetSection("Project_Link").Value.ToString();
            var projects = dbcontext.projects.ToList();

            return View(projects);
        }

        [HttpPost]
        public IActionResult AddNewProject(ProjectModel project)
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
                Project Project = new Project
                {
                    Project_Name = project.Project_Name,
                    Project_Link = project.Project_Link

                };
                dbcontext.projects.Add(Project);
                dbcontext.SaveChanges();
                ViewBag.Success = true;
                return View();
            }
        }


        [HttpGet]
        public IActionResult AddNewProject()
        {
            ViewBag.Title = "Project  | AddNewProject";

            return View();
        }

        [HttpPost]

       

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Title = " Project | Edit";
            
            Project project = dbcontext.projects.FirstOrDefault(i => i.Project_ID == id);
            ProjectModel projectModel = new ProjectModel
            {

              
                Project_Name = project.Project_Name
            };
            return View(projectModel);
        }

        [HttpPost]
        public IActionResult Edit(ProjectModel model)
        {
            Project project = dbcontext.projects.FirstOrDefault(i => i.Project_ID == model.Project_ID);
            project.Project_Name = model.Project_Name;
            dbcontext.projects.Update(project);
            dbcontext.SaveChanges();
            return RedirectToAction("AllProjects");
        }

        [HttpGet]
        public IActionResult Delete(Project project)
        {
            dbcontext.projects.Remove(project);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
