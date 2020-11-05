using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseIntegration
{
    public class IAssigneeService : IAssignee
    {
        private readonly ApplicationContext dbContext;
        public IAssigneeService(ApplicationContext context)
        {
            dbContext = context;
        }
        public List<Assignee> ShowAssignees()
        {
            if (dbContext.Assignees.Any())
            {
                return dbContext.Assignees.ToList();
            }
            return new List<Assignee>();
            
        }
        public void AddAssignee(Assignee assignee)
        {
            dbContext.Add(assignee);
            dbContext.SaveChanges();
        }

        public void EditName(string name,int Id)
        {
            var newassignee = dbContext.Assignees.FirstOrDefault(a => a.Id == Id);
            newassignee.Name = name;
            dbContext.Update(newassignee);
            dbContext.SaveChanges();
        }

        public void RemoveAssignee(Assignee assignee)
        {
            dbContext.Remove(assignee);
            dbContext.SaveChanges();
        }
        public List<Todo> ShowAssigneeTodos(int id)
        {
            var todos = dbContext.Todos.Include(t => t.Assigneer).Where(t => t.Assigneer.Id ==id).ToList();
            return todos;
        }
    }
}
