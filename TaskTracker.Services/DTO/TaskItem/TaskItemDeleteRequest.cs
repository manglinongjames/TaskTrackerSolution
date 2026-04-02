using System.ComponentModel.DataAnnotations;

namespace TaskTracker.WebAPI.DTO.TaskItem
{
    public class TaskItemDeleteRequest
    {
        [Required(ErrorMessage = "Task Item Id is required")]
        public Guid Id { get; set; } = Guid.NewGuid();

    }
}
