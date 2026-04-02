using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Core.Entities;
using TaskTracker.Core.Interfaces;
using TaskTracker.Services.Interfaces;
using TaskTracker.WebAPI.DTO.TaskItem;

namespace TaskTracker.Services.Implementations
{
    public class TaskItemGetterService : ITaskItemGetterService
    {
        private readonly ITaskRepository _ITaskRepository;

        public TaskItemGetterService(ITaskRepository taskRepository)
        {
            this._ITaskRepository = taskRepository;
        }
        public async Task<IEnumerable<TaskItemResponse>> GetAllTasksAsync()
        {
            var tasks = await _ITaskRepository.GetAllTaskAsync();
            return tasks.Select(t => MapToResponse(t));
        }

        // Private mapping helper
        private TaskItemResponse MapToResponse(TaskItem task)
        {
            return new TaskItemResponse
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                DueDate = task.DueDate
            };
        }
    }
}
