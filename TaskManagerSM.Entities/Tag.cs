using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerSM.Entities
{
    public class Tag : DomainObject
    {
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        public ICollection<TagsInTask> Tasks { get; set; }
    }
}