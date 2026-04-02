using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Core.Entities;

namespace TaskTracker.Core.Interfaces
{
    public interface ITaskRepository
    {
        /// <summary>
        /// Get all task items from the repository
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TaskItem>> GetAllTaskAsync();

        /// <summary>
        /// Get task item by ID from the repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TaskItem?> GetTaskByIdAsync(Guid id);

        /// <summary>
        /// Add an new task item to the repository
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Task<TaskItem> AddTaskAsync(TaskItem task);

        /// <summary>
        /// Update an existing task item in the repository
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Task<TaskItem> UpdateTaskAsync(TaskItem task);

        /// <summary>
        /// Delete a task item by ID from the repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteTaskAsync(Guid id);

        // Example domain-specific method
        //Task<IEnumerable<TaskItem>> GetTasksByStatusAsync(string status);
    }
}
