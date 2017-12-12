using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagerSM.ViewModel.Tasks;

namespace TaskManagerSM.DataAccess.Tasks
{
    public interface IDeleteTagFromTaskCommand
    {
        Task<TaskResponse> ExecuteAsync(int taskId, string tag);
    }
}
