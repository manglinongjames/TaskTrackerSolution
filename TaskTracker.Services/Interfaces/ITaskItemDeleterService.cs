using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Services.Interfaces
{
    public interface ITaskItemDeleterService
    {
        Task<bool> DeleteTaskAsync(Guid id);
    }
}
