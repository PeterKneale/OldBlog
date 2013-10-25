using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BackboneMvc.Data;
using BackboneMvc.Web.Models;

namespace BackboneMvc.Web.Controllers
{
    public class TodosController : ApiController
    {
        private IRepository<Todo> repository = null;

        public TodosController()
        {
            repository = new TodoRepository();
        }

        public TodosController(IRepository<Todo> repository)
        {
            this.repository = repository;
        }

        [System.Web.Mvc.HttpGet]
        public IEnumerable<TodoViewModel> Get()
        {
            var todos = repository.FindAll();
            var list = new List<TodoViewModel>();
            foreach (Todo t in todos)
                list.Add(new TodoViewModel(t));
            return list;
        }

        [System.Web.Mvc.HttpPost]
        public TodoViewModel Post(TodoViewModel newTodo)
        {
            var todo = new Todo{Done = newTodo.done, Order = newTodo.order, Text = newTodo.text};
            repository.Add(todo);
            repository.Save();
            return new TodoViewModel(todo);
        }

        [System.Web.Mvc.HttpPut]
        public TodoViewModel Put(int id, TodoViewModel newTodo)
        {
            var todo = repository.Get(id);
            todo.Done = newTodo.done;
            todo.Text = newTodo.text;
            todo.Order = newTodo.order;
            repository.Save();
            return new TodoViewModel(todo);
        }

        [System.Web.Mvc.HttpDelete]
        public object Delete(int id)
        {
            var todo = repository.Get(id);
            if (todo != null)
            {
                repository.Delete(todo);
                repository.Save();
            }
            return (new { });
        }

    }
}
