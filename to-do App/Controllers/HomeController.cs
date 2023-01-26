using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using to_do_App.Models;
using to_do_App.Models.Repository;

namespace to_do_App.Controllers
{
    public class HomeController : Controller
    {
        ITaskRepository taskRepository;
        public HomeController(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }
        public IActionResult Index()
        {
            var data=taskRepository.GetAllTasks();
            return View(data);
        }
    }
}