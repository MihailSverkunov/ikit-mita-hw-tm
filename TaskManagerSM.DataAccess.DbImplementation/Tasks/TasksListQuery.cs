using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerSM.DataAccess.Tasks;
using TaskManagerSM.Db;
using TaskManagerSM.ViewModel;
using TaskManagerSM.ViewModel.Tasks;

namespace TaskManagerSM.DataAccess.DbImplementation.Tasks
{
    public class TasksListQuery : ITasksListQuery
    {
        private TasksContext _context { get; }
        public TasksListQuery(TasksContext context)
        {
            _context = context;
        }

        public async Task<ListResponse<TaskResponse>> RunAsync(TaskFilter filter, ListOptions options)
        {
            var task = _context.Tasks
                .Include(t => t.Tags).ThenInclude(tt => tt.Tag)
                .Include(p => p.Project);

            IQueryable<TaskResponse> query = task
                .Select(p => Mapper.Map<TaskResponse>(p));
            

            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();

            if (options.Sort == null)
            {
                options.Sort = "Id";
            }

            query = options.ApplySort(query);
            query = options.ApplyPaging(query);

            return new ListResponse<TaskResponse>
            {
                Items = await query.ToListAsync(),
                Page = options.Page,
                PageSize = options.PageSize ?? totalCount,
                Sort = options.Sort,
                TotalItemsCount = totalCount
            };
        }

        private IQueryable<TaskResponse> ApplyFilter(IQueryable<TaskResponse> query, TaskFilter filter)
        {
            if (filter.Id != null)
            {
                query = query.Where(t => t.Id == filter.Id);
            }

            if (filter.Name != null)
            {
                query = query.Where(t => t.Name.StartsWith(filter.Name));
            }

            if (filter.DueDate != null)
            {
                if (filter.DueDate.From != null)
                {
                    query = query.Where(t => t.DueDate >= filter.DueDate.From);
                }

                if (filter.DueDate.To != null)
                {
                    query = query.Where(t => t.DueDate <= filter.DueDate.To);
                }
            }

            if (filter.CreateDate != null)
            {
                if (filter.CreateDate.From != null)
                {
                    query = query.Where(t => t.CreateDate >= filter.CreateDate.From);
                }

                if (filter.CreateDate.To != null)
                {
                    query = query.Where(t => t.CreateDate <= filter.CreateDate.To);
                }
            }

            if (filter.CompleteDate != null)
            {
                if (filter.CompleteDate.From != null)
                {
                    query = query.Where(t => t.CompleteDate >= filter.CompleteDate.From);
                }

                if (filter.CompleteDate.To != null)
                {
                    query = query.Where(t => t.CompleteDate <= filter.CompleteDate.To);
                }
            }

            if (filter.Status != null)
            {
                query = query.Where(t => t.Status == filter.Status);
            }

            if (filter.ProjectId != null)
            {
                query = query.Where(t => t.Project.Id == filter.ProjectId);
            }

            if (filter.Tag != null)
            {
                query = query.Where(t => t.Tags.Contains(filter.Tag));
            }

            if (filter.HasDueDate != null)
            {
                query = query.Where(t => t.DueDate != null);
            }

            return query;
        }
    }
}
