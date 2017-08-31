using System;

namespace TaskManagerSM.ViewModel.Tasks
{
    public class TaskFilter
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public RangeFilter<DateTime> CreateDate { get; set; }
        public RangeFilter<DateTime> CompleteDate { get; set; }
        public RangeFilter<DateTime> DueDate { get; set; }
        public TaskStatus? Status { get; set; }
        public int? ProjectId { get; set; }
        public string Tag { get; set; }
        public bool? HasDueDate { get; set; }
    }
}