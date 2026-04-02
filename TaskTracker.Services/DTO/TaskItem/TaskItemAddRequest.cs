using System.ComponentModel.DataAnnotations;

namespace TaskTracker.TaskTracker.Services.DTO.TaskItem
{
    public class TaskItemAddRequest
    {

        [Required(ErrorMessage = "Task Item is required")]
        [StringLength(100)]
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
