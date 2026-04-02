using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Core.Entities;
using TaskTracker.Core.Interfaces;
using TaskTracker.Infrastructure.DatabaseContext;

namespace TaskTracker.Infrastructure.Repositories
{

    public class TaskItemRepository : ITaskRepository
    {
        private readonly ILogger<TaskItemRepository> _logger;

        private readonly ApplicationDbContext _context;
        public TaskItemRepository(ApplicationDbContext context, ILogger<TaskItemRepository> logger)
        {
            this._context = context;
            this._logger = logger;
        }
        public async Task<TaskItem> AddTaskAsync(TaskItem task)
        {
            //// Add the new task to the database context and save changes
            _context.TaskItem.Add(task);

            //// Save the new task to the database. This will generate the Id for the task and persist it in the database.
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<TaskItem> UpdateTaskAsync(TaskItem task)
        {
            //_context.Entry(task).State = EntityState.Modified;
            // persist update in the database.
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> DeleteTaskAsync(Guid id)
        {
            var task = await _context.TaskItem.FindAsync(id);
            if (task == null)
            {
                return false;
            }

            // mark the entity for deletion.
            _context.TaskItem.Remove(task);

            // persist the deletion in the database.
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TaskItem>> GetAllTaskAsync()
        {
            _logger.LogInformation("Get All Task Items of Task Item Repository");
            return await _context.TaskItem.ToListAsync();
        }

        public async Task<TaskItem?> GetTaskByIdAsync(Guid id)
        {
            return await _context.TaskItem.FirstOrDefaultAsync(t => t.Id == id);
        }



 
    }
}
