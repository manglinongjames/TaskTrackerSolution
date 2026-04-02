using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.TaskTracker.Services.DTO.TaskItemDto;
using TaskTracker.WebAPI.DTO.TaskItemDto;

namespace TaskTracker.Services.Interfaces
{
    public interface ITaskItemAdderService
    {
        Task<TaskItemResponse> CreateTaskAsync(TaskItemAddRequestDto? dto);
    }
}
