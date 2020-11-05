using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DatabaseIntegration.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseIntegration.Controllers
{
    [Route("/")]
    public class TodoController : Controller
    {
        private readonly ITodoService todoservices;
        private readonly IAssigneeService assigneeService;
        public TodoController(ITodoService service,IAssigneeService assignee)
        {
            todoservices = service;
            assigneeService = assignee;
        }
        [HttpGet("/")]
        public IActionResult List(bool isActive)
        {
            var list = todoservices.ShowList(isActive);
            return View("List",list);
        }
        
        [HttpGet("/list")]
        public IActionResult ShowList()
        {
            return List(false);
        }
        [HttpGet("/todo/add")]
        public IActionResult AddTaskView()
        {
            return View("Add");
        }
        [HttpPost("/todo/add")]
        public IActionResult AddTask(Todo todo)
        {
            todoservices.AddTask(todo);
            return List(false);
        }

        [HttpGet("/{id}/delete")]
        public IActionResult DeleteTask(long id)
        {
            todoservices.DeleteTask(id);
            return List(false);
        }

        [HttpGet("/todo/edit")]
        public IActionResult EditTaskView(IndexViewModel model)
        {
            model.Assignees = assigneeService.ShowAssignees();
            model.Todos = todoservices.Todos();
            return View("Edit",model);
        }

        [HttpPost("todo/edit")]
        public IActionResult EditTask(Todo editedTask,int assigneeId)
        {
            
            todoservices.EditTask(editedTask,assigneeId);

            return List(false);
        }

        [HttpGet("/search")]
        public IActionResult SearchTask(string search)
        {
            return View("List", todoservices.Search(search));
        }
    }
}
