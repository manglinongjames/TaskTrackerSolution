
using System.ComponentModel.DataAnnotations;
using TaskTracker.Core.Entities;

namespace TaskTracker.TaskTracker.Services.DTO.TaskItemDto
{
    public class TaskItemUpdateRequestDto
    {
        //[Required(ErrorMessage = "Task Item Id is required")]
        public Guid Id { get; set; }

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
                Id = this.Id,
                Title = this.Title,
                Description = this.Description,
                Status = this.Status,
                DueDate = this.DueDate
            };
        }
    }
}
