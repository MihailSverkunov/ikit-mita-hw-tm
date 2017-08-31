using System.Threading.Tasks;
using TaskManagerSM.ViewModel.Projects;

namespace TaskManagerSM.DataAccess.Projects
{
    public interface ICreateProjectCommand
    {
        Task<ProjectResponse> ExecuteAsync(CreateProjectRequest request);
    }
}