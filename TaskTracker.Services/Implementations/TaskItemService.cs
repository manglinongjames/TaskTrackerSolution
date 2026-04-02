using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Core.Entities;
using TaskTracker.Core.Interfaces;
using TaskTracker.Services.Interfaces;
using TaskTracker.TaskTracker.Services.DTO.TaskItem;
using TaskTracker.WebAPI.DTO.TaskItem;

namespace TaskTracker.Services.Implementations
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskRepository _ITaskRepository;
        public TaskItemService(ITaskRepository iTaskRepository)
        {
            this._ITaskRepository = iTaskRepository;
        }
        public Task<TaskItemAddRequest> CreateTaskAsync(TaskItemAddRequest dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTaskAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TaskItemResponse>> GetAllTasksAsync()
        {
            var tasks = await _ITaskRepository.GetAllTaskAsync();
            return tasks.Select(t => MapToResponse(t));
        }

        public Task<TaskItemResponse?> GetTaskByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TaskItemUpdateRequest?> UpdateTaskAsync(TaskItemUpdateRequest dto)
        {
            throw new NotImplementedException();
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
