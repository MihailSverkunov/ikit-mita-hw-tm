using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagerSM.ViewModel.Tasks;

namespace TaskManagerSM.DataAccess.Tasks
{
    public interface ICreateTaskCommand
    {
        Task<TaskResponse> ExecuteAsync(CreateTaskRequest request);
    }
}
