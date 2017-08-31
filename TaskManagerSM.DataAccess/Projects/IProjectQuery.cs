using System.Threading.Tasks;
using TaskManagerSM.ViewModel.Projects;

namespace TaskManagerSM.DataAccess.Projects
{
    public interface IProjectQuery
    {
        Task<ProjectResponse> RunAsync(int projectId);
    }
}