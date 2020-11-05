using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace DatabaseIntegration.Services
{
    public class TodoService: ITodoService 
    {
        private readonly ApplicationContext dbContext;
        public TodoService(ApplicationContext context)
        {
            dbContext = context;
        }

        public List<Todo> IsDoneValues()
        {
            return dbContext.Todos.Include(t => t.Assigneer).Where(t => !t.IsDone).ToList();
        }

        public List<Todo> Todos()
        {
            return dbContext.Todos.Include(t => t.Assigneer).ToList();
        }
        public List<Todo> ShowList(bool isActive)
        {
            if (isActive)
            {
                return IsDoneValues();
            }
            return Todos();
        }

        public void AddTask(Todo todo)
        {
            dbContext.Add(todo);
            dbContext.SaveChanges();
        }
        public void DeleteTask(long id)
        {
            var task = dbContext.Todos.FirstOrDefault(t => t.Id == id);
            dbContext.Todos.Remove(task);
            dbContext.SaveChanges();
        }
        public void EditTask(Todo task,int assigneeId)
        {
            var editedTask = dbContext.Todos
                                        .Include(t => t.Assigneer)
                                        .FirstOrDefault(t => t.Id == task.Id);
            var assignee = dbContext.Assignees.FirstOrDefault(a => a.Id == assigneeId);
            editedTask.Assigneer = assignee;

            //The above part is get one todo, assignee from the database and then assign todo.assignee = assignee
            editedTask.IsDone = task.IsDone;
            editedTask.IsUrgent = task.IsUrgent;

            dbContext.SaveChanges();
        }

        public List<Todo> Search(string search)
        {
            var searched = dbContext.Todos
                                    .Where(t => t.Title.Contains(search) || t.Description.Contains(search))
                                    .ToList();
            return searched;
        }
    }
}
