using System.Threading.Tasks;
using TaskManagerSM.ViewModel;
using TaskManagerSM.ViewModel.Tasks;

namespace TaskManagerSM.DataAccess.Tasks
{
    public interface ITasksListQuery
    {
        Task<ListResponse<TaskResponse>> RunAsync(TaskFilter filter, ListOptions options);
    }
}
