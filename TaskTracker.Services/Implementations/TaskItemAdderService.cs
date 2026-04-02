using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Core.Entities;
using TaskTracker.Core.Interfaces;
using TaskTracker.Services.Helpers;
using TaskTracker.Services.Interfaces;
using TaskTracker.TaskTracker.Services.DTO.TaskItemDto;
using TaskTracker.WebAPI.DTO.TaskItemDto;

namespace TaskTracker.Services.Implementations
{
    public class TaskItemAdderService : ITaskItemAdderService
    {
        private readonly ITaskRepository _iTaskRepository;

        public TaskItemAdderService(ITaskRepository iTaskRepository)
        {
            this._iTaskRepository = iTaskRepository;
        }
        public async Task<TaskItemResponse> CreateTaskAsync(TaskItemAddRequestDto? taskItemAddRequest)
        {
            //check if taskItemAddRequest DTO is not null
            if (taskItemAddRequest == null)
            {
                throw new ArgumentNullException(nameof(taskItemAddRequest));
            }

            // validate the taskItemAddRequest DTO
            ValidationHelper.ModelValidation(taskItemAddRequest);
            ValidationHelper.ValidateTaskItemStatus(taskItemAddRequest.Status);
            ValidationHelper.ValidateTaskItemDueDate(taskItemAddRequest.DueDate);
            TaskItem taskItem = taskItemAddRequest.ToTaskItem();

            // generate a new Guid for the task item
            taskItem.Id = Guid.NewGuid();

            // add the task item to the database
            var task = await _iTaskRepository.AddTaskAsync(taskItem);

            // return the task item as a TaskItemResponse DTO
            return task.ToTaskItemResponse();
        

        }
    }
}
