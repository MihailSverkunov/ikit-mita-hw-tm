using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagerSM.ViewModel.Tags;

namespace TaskManagerSM.DataAccess.Tasks
{
    public interface IAddTagToTaskCommand
    {
        Task ExecuteAsync(int taskId, string tag);
    }
}
