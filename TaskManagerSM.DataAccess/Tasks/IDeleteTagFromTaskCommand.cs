using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerSM.DataAccess.Tasks
{
    public interface IDeleteTagFromTaskCommand
    {
        Task ExecuteAsync(int taskId, string tag);
    }
}
