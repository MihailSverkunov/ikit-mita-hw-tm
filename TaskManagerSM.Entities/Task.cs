using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerSM.Entities
{
    public class Task : DomainObject
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(4096)]
        public string Description { get; set; }

        [Required]
        public DateTime CreateDate { get; }

        public DateTime? DueDate { get; set; }

        public DateTime? CompleteDate { get; }

        [Required]
        public TaskStatus Status { get; set; }

        public ICollection<TagsInTask> Tags { get; set; }

        public int ProjectId { get; set; }
        [Required]
        public Project Project { get; set; }
    }
}