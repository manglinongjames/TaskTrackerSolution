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
        public Task AddTaskAsync(TaskItem task)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTaskAsync(Guid id)
        {
            throw new NotImplementedException();
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

        public Task UpdateTaskAsync(TaskItem task)
        {
            throw new NotImplementedException();
        }
    }
}
