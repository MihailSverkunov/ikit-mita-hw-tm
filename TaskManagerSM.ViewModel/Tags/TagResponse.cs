using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManagerSM.ViewModel.Tags
{
    public class TagResponse
    {
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }
        public int? TasksCount { get; set; }
        public int? OpenTasksCount { get; set; }
    }
}
