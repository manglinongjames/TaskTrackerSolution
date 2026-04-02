using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.TaskTracker.Services.DTO.TaskItem;
using TaskTracker.WebAPI.DTO.TaskItem;

namespace TaskTracker.Services.Interfaces
{
    public interface ITaskItemService
    {
        Task<IEnumerable<TaskItemResponse>> GetAllTasksAsync();
        Task<TaskItemResponse?> GetTaskByIdAsync(Guid id);
        Task<TaskItemAddRequest> CreateTaskAsync(TaskItemAddRequest dto);
        Task<TaskItemUpdateRequest?> UpdateTaskAsync(TaskItemUpdateRequest dto);
        Task DeleteTaskAsync(Guid id);
    }
}
