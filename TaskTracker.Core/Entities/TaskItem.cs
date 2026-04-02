using System;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Core.Entities
{
    /// <summary>
    /// Domain entity representing a task item in the Task Tracker application. It includes properties such as Id, Title, Description, Status, and DueDate. The Id is a unique identifier for each task item, while the Title is a required field with a maximum length of 100 characters. The Description, Status, and DueDate are optional fields that provide additional information about the task item.
    /// </summary>
    public class TaskItem
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage ="Task Item is required")]
        [StringLength(100)]
        public string Title { get; set; }

        public string? Description { get; set; }

        public string? Status { get; set; }

        public DateTime? DueDate { get; set; }

    }
}
