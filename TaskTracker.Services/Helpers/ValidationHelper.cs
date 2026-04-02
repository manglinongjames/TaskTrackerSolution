using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Services.Helpers
{
    public class ValidationHelper
    {
        public static void ModelValidation(object obj)
        {
            //Model Validations
            ValidationContext validationContext = new ValidationContext(obj);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            if (!isValid)
            {
                throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage);
            }

        }

        public static void ValidateTaskItemStatus(string status)
        {
            var validStatuses = new List<string> { "todo", "inprogress", "done" };
            if (!validStatuses.Contains(status?.ToLower()))
            {
                throw new ArgumentException($"Invalid status value. Valid values are: {string.Join(", ", validStatuses)}");
            }
        }

        public static void ValidateTaskITemStatusTransition(string newStatus, string currentStatus)
        {
            //skip 'inprogress'
            if (currentStatus?.ToLower() == "todo" && newStatus?.ToLower() == "done")
            {
                throw new InvalidOperationException($"The task is currently '{currentStatus}' state and must be marked 'InProgress' first before it can be updated to 'Done'.");
            }

            //from done to inprogress or todo
            if (currentStatus?.ToLower() == "done" && (newStatus?.ToLower() == "inprogress" || newStatus?.ToLower() == "todo"))
            {
                throw new InvalidOperationException($"The task is currently '{currentStatus}' state and cannot be updated to '{newStatus}'.");
            }

            // from inprogress to todo
            if (currentStatus?.ToLower() == "inprogress" && newStatus?.ToLower() == "todo")
            {
                throw new InvalidOperationException($"The task is currently '{currentStatus}' state and cannot be updated to '{newStatus}'.");
            }
        }

        public static void ValidateTaskItemDueDate(DateTime? dueDate)
        {
            if (dueDate.HasValue && dueDate.Value < DateTime.UtcNow.Date)
            {
                throw new ArgumentException("Due date must be today or a future date or leave it blank.");
            }
        }

    }
}
