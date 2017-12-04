using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerSM.DataAccess.Tasks
{
    public interface IDeleteTaskCommand
    {
        Task ExecuteAsync(int taskId);
    }
}
