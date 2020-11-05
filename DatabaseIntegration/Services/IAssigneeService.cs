using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseIntegration
{
    public interface IAssignee
    {
        List<Assignee> ShowAssignees();
        void EditName(string name,int Id);
        void RemoveAssignee(Assignee assignee);
        void AddAssignee(Assignee assignee);
        List<Todo> ShowAssigneeTodos(int id);
    }
}
