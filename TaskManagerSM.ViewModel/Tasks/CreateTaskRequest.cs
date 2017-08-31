using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerSM.ViewModel.Tasks
{
    public class CreateTaskRequest
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(4096)]
        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public string[] Tags { get; set; }

        [Required]
        public int ProjectId { get; set; }
    }
}