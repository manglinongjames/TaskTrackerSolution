using TaskTracker.Core.Interfaces;
using TaskTracker.Services.Helpers;
using TaskTracker.Services.Interfaces;
using TaskTracker.TaskTracker.Services.DTO.TaskItemDto;
using TaskTracker.WebAPI.DTO.TaskItemDto;

namespace TaskTracker.Services.Implementations
{
    public class TaskItemUpdaterService : ITaskItemUpdaterService
    {
        private readonly ITaskRepository _iTaskRepository;

        public TaskItemUpdaterService(ITaskRepository iTaskRepository)
        {
            this._iTaskRepository = iTaskRepository;
        }
        public async Task<TaskItemResponse> UpdateTaskAsync(TaskItemUpdateRequestDto taskItemUpdateRequestDto)
        {
            //check if taskItemAddRequest DTO is not null
            if (taskItemUpdateRequestDto == null)
            {
                throw new KeyNotFoundException(nameof(taskItemUpdateRequestDto));
            }



            //validate the taskItemAddRequest DTO
            //ValidationHelper.ModelValidation(taskItemUpdateRequestDto);
            ValidationHelper.ValidateTaskItemStatus(taskItemUpdateRequestDto.Status);
          
            if (string.IsNullOrWhiteSpace(taskItemUpdateRequestDto.Title) && taskItemUpdateRequestDto.Status?.ToLower() == "done")
            {
                throw new InvalidOperationException("Unable to mark the task item to 'Done' due to missing title.");
            }

            var existingTaskItem = await _iTaskRepository.GetTaskByIdAsync(taskItemUpdateRequestDto.Id);

            if (existingTaskItem == null)
            {
                throw new KeyNotFoundException($"Task item with id {taskItemUpdateRequestDto.Id} not found.");
            }

            ValidationHelper.ValidateTaskITemStatusTransition(taskItemUpdateRequestDto.Status,existingTaskItem.Status);

            if (taskItemUpdateRequestDto.Status?.ToLower() == "done" && existingTaskItem?.Status?.ToLower() == "todo") {
                throw new InvalidOperationException($"The task is currently '{existingTaskItem?.Status}' state and must be marked 'InProgress' first before it can be updated to 'Done'.");
            }

            existingTaskItem.Title = taskItemUpdateRequestDto.Title;
            existingTaskItem.Description = taskItemUpdateRequestDto.Description;
            existingTaskItem.Status = taskItemUpdateRequestDto.Status;
            existingTaskItem.DueDate = taskItemUpdateRequestDto.DueDate;
            var task =await _iTaskRepository.UpdateTaskAsync(existingTaskItem);

            return task.ToTaskItemResponse();
        }
    }
}
