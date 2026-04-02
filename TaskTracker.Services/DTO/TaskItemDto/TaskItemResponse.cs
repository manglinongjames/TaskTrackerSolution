using System.ComponentModel.DataAnnotations;

namespace TaskTracker.WebAPI.DTO.TaskItemDto
{
    public class TaskItemResponse
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
