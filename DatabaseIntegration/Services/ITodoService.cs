using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseIntegration.Services
{
    public interface ITodoService
    {
        List<Todo> Todos();
        List<Todo> IsDoneValues();
        List<Todo> ShowList(bool isActive);
        void AddTask(Todo todo);
        void DeleteTask(long id);
        void EditTask(Todo task,int assigneeId);
        List<Todo> Search(string search);
    }
}
