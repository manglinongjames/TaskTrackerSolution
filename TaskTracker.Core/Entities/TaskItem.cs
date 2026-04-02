using System;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Core.Entities
{
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
