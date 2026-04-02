using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Services.Interfaces;
using TaskTracker.TaskTracker.Services.DTO.TaskItem;

namespace TaskTracker.Services.Implementations
{
    public class TaskItemAdderRequest : ITaskItemAdderRequest
    {
        public Task<TaskItemAddRequest> CreateTaskAsync(TaskItemAddRequest? dto)
        {
            throw new NotImplementedException();
        }
    }
}
