using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TaskManagerSM.Entities
{
    public class Tag : DomainObject
    {
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        public ICollection<TagsInTask> Tasks { get; set; }

        public int? TasksCount
        {
            get
            {
                return Tasks?.Count ?? 0;
            }
        }

        public int? OpenTasksCount
        {
            get
            {
                return Tasks?.Select(x => x.Task).Count(t => t.Status != TaskStatus.Completed) ?? 0;
            }
        }
        //ForMember("OpenTasksCount", otc => otc.MapFrom(src => src.Tasks.Count(t => t.Status != Entities.TaskStatus.Completed)
    }
}