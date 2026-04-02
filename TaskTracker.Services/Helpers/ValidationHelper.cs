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
    }
}
