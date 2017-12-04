using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerSM.DataAccess.Tags;
using TaskManagerSM.Db;
using TaskManagerSM.ViewModel;
using TaskManagerSM.ViewModel.Tags;
using TaskManagerSM.ViewModel.Tasks;

namespace TaskManagerSM.DataAccess.DbImplementation.Tags
{
    public class TagsListQuery : ITagsListQuery
    {
        private TasksContext _context { get; }
        public TagsListQuery(TasksContext context)
        {
            _context = context;
        }

        public async Task<ListResponse<TagResponse>> RunAsync(TagFilter filter, ListOptions options)
        {
            var tag = _context.Tags
                .Include(t => t.Tasks).ThenInclude(tt => tt.Task);

            IQueryable<TagResponse> query = tag
                .Select(t => Mapper.Map<TagResponse>(t));




            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();

            if (options.Sort == null)
            {
                options.Sort = "Name";
            }

            query = options.ApplySort(query);
            query = options.ApplyPaging(query);

            return new ListResponse<TagResponse>
            {
                Items = await query.ToListAsync(),
                Page = options.Page,
                PageSize = options.PageSize ?? totalCount,
                Sort = options.Sort,
                TotalItemsCount = totalCount
            };
        }

        private IQueryable<TagResponse> ApplyFilter(IQueryable<TagResponse> query, TagFilter filter)
        {

            if (filter.Name != null)
            {
                query = query.Where(pr => pr.Name.StartsWith(filter.Name));
            }


            return query;
        }
    }
}
