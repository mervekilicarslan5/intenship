using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using System.Net;
namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        //if a declare Repository instances here I would be heavily dependent on declaring them in the low level
        //instead I will use Autofac dependency injection
        //in order to pass instances we will use Constructors
        //use _ in name declaration since these are similar to the private backing field

      private IRepository<Student> _Repository;
        //IRepository<Student> Repository;
        public HomeController(IRepository<Student> Repository)
        {
            this._Repository = Repository;
            

        }
       // [HttpPost]
        public ActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        //[HttpPost]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //Post from the View
     
        
        public ActionResult Create(Student x)
        {
            Student y;
            if (ModelState.IsValid)
            {
                if (x.s_name != "")
                {

                    //stu.advisor= 
                    //use the add method here yo add a student
                    System.Diagnostics.Debug.WriteLine("come on Inside here");
                    _Repository.Add(x, out y);
                    System.Diagnostics.Debug.WriteLine(x.s_name);
                    System.Diagnostics.Debug.WriteLine("come on");

                }
            }
            return View(x);
        }
        public ActionResult List()
        {
            return View(_Repository.List());
        }
       
        public ActionResult Delete(Student x)
        {
            _Repository.Delete(x.s_id);
            return View();
        }
        public ActionResult Details (int? id)
        {
            StudentContext Stu1 = new StudentContext();

            Student part = Stu1.Students.Single(x => x.s_id == id);
            return View(part);
        }
    }
}