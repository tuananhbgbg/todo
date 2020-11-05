using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseIntegration.Controllers
{
    public class AssigneeController : Controller
    {
        private readonly IAssigneeService services;
        public AssigneeController(IAssigneeService service)
        {
            services = service;
        }
        [Route("/assignee")]
        public IActionResult Assignees()
        {
            return View("Assignees",services.ShowAssignees());
        }
        [HttpGet("/assignee/add")]
        public IActionResult AddAssigneeView()
        {
            return View("Add");
        }
        [HttpPost("/assignee/add")]
        public IActionResult AddAssignee(Assignee assignee)
        {
            services.AddAssignee(assignee);
            return RedirectToAction("Assignees");
        }
        [HttpGet("/assignee/edit")]
        public IActionResult EditAssigneeView()
        {
            return View("EditAssignee",services.ShowAssignees());
        }
        [HttpPost("/assignee/edit")]
        public IActionResult EditAssignee(string Name,int Id)
        {
            services.EditName(Name,Id);
            return RedirectToAction("Assignees");
        }
        [HttpGet("/assignee/{Id}/delete")]
        public IActionResult DeleteAssignee(Assignee assignee)
        {
            services.RemoveAssignee(assignee);
            return RedirectToAction("Assignees");
        }
        [HttpGet("/assignee/{id}")]
        public IActionResult ShowAssigneeTodos(int id)
        {
            var todos = services.ShowAssigneeTodos(id);
            return View("~/Views/Todo/List.cshtml", todos);
        }
    }
}
