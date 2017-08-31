using System.Threading.Tasks;
using TaskManagerSM.ViewModel;
using TaskManagerSM.ViewModel.Projects;

namespace TaskManagerSM.DataAccess.Projects
{
    public interface IProjectsListQuery
    {
        Task<ListResponse<ProjectResponse>> RunAsync(ProjectFilter filter, ListOptions options);
    }
}