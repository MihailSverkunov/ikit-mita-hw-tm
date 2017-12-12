using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerSM.Entities
{
    public class Task : DomainObject
    {
        public Task()
        {
            //переделать
            //if (CreateDate == default(DateTime))
            //_createDate = DateTime.Now;
            
        }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(4096)]
        public string Description { get; set; }


        private DateTime _createDate;

        [Required]
        public DateTime CreateDate
        {
            get
            {
                if (_createDate == default(DateTime))
                {
                    _createDate = DateTime.Now;
                }
                return _createDate;
            }
        }

        public DateTime? DueDate { get; set; }


        private DateTime _completeDate;
        public DateTime? CompleteDate { get; }

        private TaskStatus _status;

        [Required]
        public TaskStatus Status
        {
            get
            {
                return _status;
            }
            set
            {               
                _status = value;
                if (value == TaskStatus.Completed)
                {
                    _completeDate = DateTime.Now;
                }

            }
        }

        public ICollection<TagsInTask> Tags { get; set; }

        public int ProjectId { get; set; }
        [Required]
        public Project Project { get; set; }
    }
}