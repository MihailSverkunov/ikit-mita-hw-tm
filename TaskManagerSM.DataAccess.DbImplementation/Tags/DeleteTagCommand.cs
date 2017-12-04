using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagerSM.DataAccess.Tags;
using TaskManagerSM.Db;
using TaskManagerSM.Entities;

namespace TaskManagerSM.DataAccess.DbImplementation.Tags
{
    public class DeleteTagCommand : IDeleteTagCommand
    {
        private TasksContext _context { get; }
        public DeleteTagCommand(TasksContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task ExecuteAsync(string reqTag)
        {
            Tag tag = await _context.Tags.FirstOrDefaultAsync(t => t.Name == reqTag);
            //????????
            if (tag != null)
            {
                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Нет такого тега");
            }
        }
    }
}
