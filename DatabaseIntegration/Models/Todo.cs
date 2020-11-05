using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseIntegration
{
    public class Todo
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsUrgent { get; set; }
        public bool IsDone { get; set; }

        
        public Assignee Assigneer { get; set; }
        
        
        public Todo()
        {

        }

        public Todo(string title, bool isUrgent, bool isDone)
        {
            Title = title;
            IsUrgent = isUrgent;
            IsDone = isDone;
        }
    }
}
