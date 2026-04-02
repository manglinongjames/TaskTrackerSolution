using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Core.Interfaces;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.Services.Implementations
{
    public class TaskItemDeleterService : ITaskItemDeleterService
    {
        private readonly ITaskRepository _iTaskRepository;

        public TaskItemDeleterService(ITaskRepository iTaskRepository)
        {
            this._iTaskRepository = iTaskRepository;
        }

        public async Task<bool> DeleteTaskAsync(Guid id)
        {
            return await this._iTaskRepository.DeleteTaskAsync(id);
        }
    }
}
