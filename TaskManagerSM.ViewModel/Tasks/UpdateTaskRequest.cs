using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerSM.ViewModel.Tasks
{
    public class UpdateTaskRequest
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(4096)]
        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public string[] Tags { get; set; }

        [Required]
        public TaskStatus Status { get; set; }
    }
}