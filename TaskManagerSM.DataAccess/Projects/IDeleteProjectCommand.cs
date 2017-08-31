using System.Threading.Tasks;

namespace TaskManagerSM.DataAccess.Projects
{
    public interface IDeleteProjectCommand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        /// <exception cref="CannotDeleteProjectWithTasksException"></exception>
        Task ExecuteAsync(int projectId);
    }
}