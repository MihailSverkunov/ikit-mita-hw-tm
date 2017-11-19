using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TaskManagerSM.Entities
{
    public class Project: DomainObject
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(2048)]
        public string Description { get; set; }

        public ICollection<Task> Tasks { get; set; }

        public int? OpenTasksCount
        {
            get
            {
                return Tasks?.Count(t => t.Status != TaskStatus.Completed) ?? 0;
            }
        }
    }
}