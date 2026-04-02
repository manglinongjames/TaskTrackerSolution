using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.WebAPI.DTO.TaskItem;

namespace TaskTracker.Services.Interfaces
{

    public interface ITaskItemGetterService
    {
        Task<IEnumerable<TaskItemResponse>> GetAllTasksAsync();
    }
}
