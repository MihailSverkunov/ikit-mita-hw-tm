using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagerSM.DataAccess.Tags;

namespace TaskManagerSM.DataAccess.DbImplementation.Tags
{
    public class DeleteTagCommand : IDeleteTagCommand
    {
        public Task ExecuteAsync(string tag)
        {
            throw new NotImplementedException();
        }
    }
}
