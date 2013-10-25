using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackboneMvc.Data
{
    public interface IRepository<T>
    {
        IQueryable<T> FindAll();
        T Get(int id);
        void Save();
        T Add(T t);
        void Delete(T t);
    }

    public class TodoRepository : IRepository<Todo>
    {
        private TodoEntitiesContainer db = new TodoEntitiesContainer();

        public IQueryable<Todo> FindAll()
        {
            return db.ToDos;
        }

        public Todo Get(int id)
        {
            return db.ToDos.FirstOrDefault(c => c.Id == id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public Todo Add(Todo todo)
        {
            db.ToDos.Add(todo);
            return todo;
        }

        public void Delete(Todo todo)
        {
            db.ToDos.Remove(todo);
        }
    }
}
