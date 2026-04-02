using System.ComponentModel.DataAnnotations;

namespace TaskTracker.WebAPI.DTO.TaskItem
{
    public class TaskItemUpdateRequest
    {
        [Required(ErrorMessage = "Task Item Id is required")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Task Item is required")]
        [StringLength(100)]
        public string Title { get; set; }

        public string? Description { get; set; }

        public string? Status { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
