using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Reflection;
using TaskTracker.Core.Entities;
using TaskTracker.WebAPI.DTO.TaskItemDto;

namespace TaskTracker.TaskTracker.Services.DTO.TaskItemDto
{
    public class TaskItemAddRequestDto
    {

        //[Required(ErrorMessage = "Task Item is required")]
        [StringLength(100)]
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? DueDate { get; set; }

        public TaskItem ToTaskItem()
        {
            return new TaskItem
            {
                Title = this.Title,
                Description = this.Description,
                Status = this.Status,
                DueDate = this.DueDate
            };
        }
    }


    public static class TaskItemExtensions
    {

        public static TaskItemResponse ToTaskItemResponse(this TaskItem taskItem)
        {
            return new TaskItemResponse()
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                Status = taskItem.Status,
                DueDate = taskItem.DueDate
            };

        }

    }

}
