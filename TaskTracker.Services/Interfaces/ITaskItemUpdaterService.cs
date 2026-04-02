using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.TaskTracker.Services.DTO.TaskItemDto;
using TaskTracker.WebAPI.DTO.TaskItem;
using TaskTracker.WebAPI.DTO.TaskItemDto;

namespace TaskTracker.Services.Interfaces
{
    public interface ITaskItemUpdaterService
    {
        Task<TaskItemResponse> UpdateTaskAsync(TaskItemUpdateRequestDto taskItemUpdateRequestDto);
    }
}
