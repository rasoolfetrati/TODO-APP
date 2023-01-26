using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace to_do_App.Models.Repository
{
    public interface ITaskRepository
    {
        IEnumerable<to_do_Model> GetAllTasks();
        Task Add(string task);
        Task Delete(int id);
        Task Update(int id);
        to_do_Model GetLastItem();
    }
    public class TaskRepository : ITaskRepository
    {
        private ApplicationContext context;
        public TaskRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task Add(string task)
        {
            to_do_Model to_Do_Model = new to_do_Model()
            {
                Task = task,
                isDone = false
            };
            await context.TOdoTable.AddAsync(to_Do_Model);
            await context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task Delete(int id)
        {
            await context.TOdoTable.Where(t => t.Id == id).ExecuteDeleteAsync();
            await Task.CompletedTask;
        }

        public IEnumerable<to_do_Model> GetAllTasks()
        {
            return context.TOdoTable.ToList();
        }

        public to_do_Model GetLastItem()
        {
            return context.TOdoTable.OrderBy(t => t.Id).Last();
        }

        public async Task Update(int id)
        {
            await context.TOdoTable.Where(t => t.Id == id).ExecuteUpdateAsync(t=>t.SetProperty(x=>x.isDone,x=>!x.isDone));
            await Task.CompletedTask;
        }
    }
}
