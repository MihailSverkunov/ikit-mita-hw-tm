using System.Threading.Tasks;
using TaskManagerSM.ViewModel.Projects;

namespace TaskManagerSM.DataAccess.Projects
{
    public interface IUpdateProjectCommand
    {
        Task<ProjectResponse> ExecuteAsync(int projectId, UpdateProjectRequest request);
    }
}