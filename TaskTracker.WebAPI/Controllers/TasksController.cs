
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Core.Entities;
using TaskTracker.Infrastructure.DatabaseContext;

namespace TaskTracker.WebAPI.Controllers
{
    public class TasksController : CustomControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Tasks
        /// <summary>
        /// Returns a list of all tasks in the database. If no tasks exist, an empty collection is returned. The response is in JSON format due to the [ApiController] attribute, which automatically serializes the response to JSON.
        /// </summary>
        /// <returns>A collection of <see cref="TaskItem"/> objects representing all tasks. The collection is empty if no tasks
        /// exist.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
        {
            
            var tasks = await _context.TaskItem.ToListAsync();

            return tasks;
        }

        // GET: api/Tasks/5
        /// <summary>
        /// returns a 404 Not Found response if the task with the specified id is not found in the database, along with a custom error message in the response body. 
        /// If the task is found, it returns the task object in JSON format.
        /// Use ActionResult<TaskItem> to return TaskItem object if found, otherwise return a ProblemDetails response with a 404 Not Found status code and a custom error message in the response body.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTask(Guid id)
        {
            //var task = await _context.TaskItem.FindAsync(id);
            var task = await _context.TaskItem.FirstOrDefaultAsync(a => a.Id == id);

            if (task == null)
            {
                //Response.StatusCode = StatusCodes.Status404NotFound;
                //return NotFound();

                /// return a ProblemDetails response with a 404 Not Found status code and a custom error message in the response body.\
                /// returns a json result
                return Problem(statusCode: StatusCodes.Status404NotFound, detail: $"Task with id {id} not found.", title: "Task Search");
            }

            // returns json format, because of [ApiController] attribute, which automatically serializes the response to JSON
            return task;
        }

        // PUT: api/Tasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Route paramenter name and method paramenter name should be same, otherwise it will not bind the value from route to method parameter and you will get 400 bad request error
        /// Use IActionResult as the return type of the method, which allows you to return different types of responses (e.g., 204 No Content, 404 Not Found, etc.) based on the outcome of the update operation.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(Guid id, TaskItem task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            /// update the object and set the state into modified.
            /// however, this approach will update all the properties of the entity, even if only one property is changed.
            _context.Entry(task).State = EntityState.Modified;

            // to upate entity using specific values
            //var existingTask = await _context.TaskItem.FindAsync(id);

            //if (existingTask == null) {
            //    return NotFound(); //http 404
            //}

            //existingTask.Status = task.Status;




            try
            {
                // persist update in the database.
                await _context.SaveChangesAsync();
            }
            // if another user has updated the same entity in the database after we fetched it and before we tried to update it, then a DbUpdateConcurrencyException will be thrown.
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    // rethrow the exception to be handled by the global exception handler, which will return a 500 Internal Server Error response to the client.
                    throw;
                }
            }

            /// return 204 No Content status code, which indicates that the request was successful but there is no content to return in the response body.
            return NoContent();
        }

        // POST: api/Tasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskItem>> PostTask(TaskItem task)
        {
            // no need for this check, because of [ApiController] attribute, which automatically validates the model and returns a 400 Bad Request response if the model is invalid.
            //if (ModelState.IsValid == false)
            //{
            //    return BadRequest(ModelState);
            //}

            // check if the TaskItem DbSet is null, which indicates a problem with the database context configuration.
            // If it is null, return a ProblemDetails response with a 500 Internal Server Error status code
            // and a custom error message in the response body.
            if (_context.TaskItem == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TaskItem' is null.");
            }

            // Ensure the server generates the Id regardless of client input
            task.Id = Guid.NewGuid();

            // Add the new task to the database context and save changes
            _context.TaskItem.Add(task);

            // Save the new task to the database. This will generate the Id for the task and persist it in the database.
            await _context.SaveChangesAsync();

            // Automatically return a 201 Created response with the location of the newly created task and the task object in the response body.
            // https://localhost:7221/api/Tasks/9801a9c5-0098-4690-9568-6589e8e1b665
            return CreatedAtAction("GetTask", new { id = task.Id }, task);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var task = await _context.TaskItem.FindAsync(id);
            if (task == null)
            {
                return NotFound(); // http 404
            }

            // mark the entity for deletion.
            _context.TaskItem.Remove(task);

            // persist the deletion in the database.
            await _context.SaveChangesAsync();

            // return 204 No Content status code, which indicates that the request was successful but there is no content to return in the response body.
            return NoContent();
        }

        private bool TaskExists(Guid id)
        {
            return _context.TaskItem.Any(e => e.Id == id);
        }
    }
}
