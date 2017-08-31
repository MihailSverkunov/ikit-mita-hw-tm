namespace TaskManagerSM.ViewModel.Projects
{
    public class ProjectResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OpenTasksCount { get; set; }
    }
}