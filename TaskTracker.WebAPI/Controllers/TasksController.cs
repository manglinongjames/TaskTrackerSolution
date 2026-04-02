
using Microsoft.AspNetCore.Mvc;

using TaskTracker.Core.Entities;

using TaskTracker.Services.Interfaces;
using TaskTracker.TaskTracker.Services.DTO.TaskItemDto;
using TaskTracker.WebAPI.DTO.TaskItemDto;

namespace TaskTracker.WebAPI.Controllers
{
    public class TasksController : CustomControllerBase
    {


        private readonly ITaskItemGetterService _iTaskItemGetterService;
        private readonly ITaskItemAdderService _iTaskItemAdderRequest;
        private readonly ITaskItemUpdaterService _iTaskItemUpdaterService;
        private readonly ITaskItemDeleterService _iTaskItemDeleterService;
        public TasksController(
            ITaskItemGetterService taskItemService,
            ITaskItemAdderService iTaskItemAdderRequest,
            ITaskItemUpdaterService taskItemUpdaterService,
            ITaskItemDeleterService iTaskItemDeleterService)
        {
            this._iTaskItemGetterService = taskItemService;
            this._iTaskItemAdderRequest = iTaskItemAdderRequest;
            this._iTaskItemUpdaterService = taskItemUpdaterService;
            this._iTaskItemDeleterService = iTaskItemDeleterService;
        }

        // GET: api/Tasks
        /// <summary>
        /// This endpoint retrieves a list of all task items in the system, including their details such as title, description, status, and due date.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItemResponse>>> GetTasks()
        {
            var tasks = await _iTaskItemGetterService.GetAllTasksAsync();
            return Ok(tasks);
        }

        // GET: api/Tasks/5
        /// <summary>
        /// This endpoint retrieves a specific task item by its unique identifier (ID). It returns the details of the task, including its title, description, status, and due date. If the task with the specified ID does not exist, it returns a 404 Not Found response.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTask(Guid id)
        {
            try
            {
                var task = await _iTaskItemGetterService.GetTaskByIdAsync(id);
                return Ok(task);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // PUT: api/Tasks/5
        /// <summary>
        /// This endpoint updates an existing task item identified by its unique identifier (ID). It accepts a request body containing the updated details of the task, such as title, description, status, and due date. If the task with the specified ID does not exist, it returns a 404 Not Found response. If the update is successful, it returns the updated task details. If there are validation errors or other issues with the request, it returns a 400 Bad Request response with an appropriate error message.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(Guid id, TaskItemUpdateRequestDto task)
        {
            if (id != task.Id)
            {
                return BadRequest("Id mismatch");
            }

            try
            {
                var taskItemResponse = await _iTaskItemUpdaterService.UpdateTaskAsync(task);
                return Ok(taskItemResponse);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (InvalidOperationException ex) {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Tasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// This endpoint creates a new task item in the system. It accepts a request body containing the details of the task to be created, such as title, description, status, and due date. If the creation is successful, it returns a 201 Created response with the details of the newly created task, including its unique identifier (ID). If there are validation errors or other issues with the request, it returns a 400 Bad Request response with an appropriate error message.
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<TaskItemResponse>> PostTask(TaskItemAddRequestDto task)
        {
            try
            {
                var taskItemResponse = await _iTaskItemAdderRequest.CreateTaskAsync(task);
                return CreatedAtAction("GetTask", new { id = taskItemResponse.Id }, taskItemResponse);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Tasks/5
        /// <summary>
        /// This endpoint deletes an existing task item identified by its unique identifier (ID). If the task with the specified ID does not exist, it returns a 404 Not Found response. If the deletion is successful, it returns a 204 No Content response, indicating that the task has been successfully deleted from the system.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var task = await _iTaskItemDeleterService.DeleteTaskAsync(id);
            if (!task)
            {
                return NotFound(); // http 404
            }
            // If the deletion is successful, return a 204 No Content response
            return NoContent();
        }

    }
}
