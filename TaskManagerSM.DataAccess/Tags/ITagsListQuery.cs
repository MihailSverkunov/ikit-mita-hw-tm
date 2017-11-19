using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagerSM.ViewModel;
using TaskManagerSM.ViewModel.Tags;

namespace TaskManagerSM.DataAccess.Tags
{
    public interface ITagsListQuery
    {
        Task<ListResponse<TagResponse>> RunAsync(TagFilter filter, ListOptions options);
    }
}
