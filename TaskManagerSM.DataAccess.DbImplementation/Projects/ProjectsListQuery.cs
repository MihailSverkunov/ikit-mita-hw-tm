using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManagerSM.DataAccess.Projects;
using TaskManagerSM.Db;
using TaskManagerSM.Entities;
using TaskManagerSM.ViewModel;
using TaskManagerSM.ViewModel.Projects;


namespace TaskManagerSM.DataAccess.DbImplementation.Projects
{
    public class ProjectsListQuery : IProjectsListQuery
    {
        private TasksContext _context { get; }
        public ProjectsListQuery(TasksContext context)
        {
            _context = context;
        }

        public async Task<ListResponse<ProjectResponse>> RunAsync(ProjectFilter filter, ListOptions options)
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<Project, ProjectResponse>()
            //                            .ForMember("OpenTasksCount", otc => otc.MapFrom(src => src.Tasks.Count(t => t.Status != Entities.TaskStatus.Completed))));

            IQueryable <ProjectResponse> query = _context.Projects
                .Select(p => Mapper.Map<ProjectResponse>(p));
            //{
            //    Id = p.Id,
            //    Name = p.Name,
            //    Description = p.Description,
            //    OpenTasksCount = p.Tasks.Count(t => t.Status != Entities.TaskStatus.Completed)
            //}

            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();

            if (options.Sort == null)
            {
                options.Sort = "Id";
            }

            query = options.ApplySort(query);
            query = options.ApplyPaging(query);

            return new ListResponse<ProjectResponse>
            {
                Items = await query.ToListAsync(),
                Page = options.Page,
                PageSize = options.PageSize ?? totalCount,
                Sort = options.Sort,
                TotalItemsCount = totalCount
            };
        }

        private IQueryable<ProjectResponse> ApplyFilter(IQueryable<ProjectResponse> query, ProjectFilter filter)
        {
            if (filter.Id != null)
            {
                query = query.Where(pr => pr.Id == filter.Id);
            }

            if (filter.Name != null)
            {
                query = query.Where(pr => pr.Name.StartsWith(filter.Name));
            }

            if (filter.OpenTasksCount != null)
            {
                if (filter.OpenTasksCount.From != null)
                {
                    query = query.Where(pr => pr.OpenTasksCount >= filter.OpenTasksCount.From);
                }

                if (filter.OpenTasksCount.To != null)
                {
                    query = query.Where(pr => pr.OpenTasksCount <= filter.OpenTasksCount.To);
                }
            }

            return query;
        }
    }
}
