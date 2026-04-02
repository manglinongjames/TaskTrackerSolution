using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.TaskTracker.Services.DTO.TaskItem;

namespace TaskTracker.Services.Interfaces
{
    public interface ITaskItemAdderRequest
    {
        Task<TaskItemAddRequest> CreateTaskAsync(TaskItemAddRequest? dto);
    }
}
