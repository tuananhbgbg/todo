using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseIntegration
{
    public class IndexViewModel
    {
        public List<Todo> Todos { get; set; }
        public List<Assignee> Assignees { get; set; }
        public IndexViewModel()
        {

        }
    }
}
