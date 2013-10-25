using System.Collections.Generic;
using System.Web.Mvc;
using BackboneMvc.Data;
using BackboneMvc.Web.Models;

namespace BackboneMvc.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Todo> repository = null;

        public HomeController()
        {
            repository = new TodoRepository();
        }

        public HomeController(IRepository<Todo> repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            var todos = repository.FindAll();

            var list = new List<TodoViewModel>();
            foreach (Todo t in todos)
                list.Add(new TodoViewModel(t));

            return View(list);
        }
    }
}
