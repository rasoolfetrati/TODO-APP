using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using to_do_App.Models.Repository;

namespace to_do_App.Controllers
{
    [ApiController]
    public class TOdoController : ControllerBase
    {
        ITaskRepository taskRepository;
        public TOdoController(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }
        [HttpPost]
        [Route("SaveTask/{task}")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> SaveTask(string task)
        {
            if (string.IsNullOrWhiteSpace(task))
            {
                return BadRequest("Task is empty");
            }
            await taskRepository.Add(task);
            return Ok("Done");
        }
        [HttpGet]
        [Route("GetAll")]
        [IgnoreAntiforgeryToken]
        public IActionResult GetAllTasks()
        {
            var result = taskRepository.GetAllTasks();
            return Ok(new JsonResult(result));
        }
        [HttpGet]
        [Route("GetLastItem")]
        [IgnoreAntiforgeryToken]
        public IActionResult GetLastItem()
        {
            var result = taskRepository.GetLastItem();
            return Ok(new JsonResult(result));
        }
        [HttpDelete]
        [Route("DeleteTask/{id}")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await taskRepository.Delete(id);
            return Ok("Task Deleted successfully!");
        }
        [HttpPut]
        [Route("UpdateTask/{id}")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> UpdateTask(int id)
        {
            await taskRepository.Update(id);
            return Ok("Task Done!");
        }
    }
}
