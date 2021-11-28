using DivisionOfWorkModels.ViewModels;
using DivisionOfWorkWebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DivisionOfWorkWebAPI.Reponsitories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DivisionOfWorkDbContext _context;
        public TaskRepository(DivisionOfWorkDbContext context)
        {
            _context = context;
        }

        //GET TASK LIST
        public async Task<IEnumerable<Entities.Task>> GetTaskList(TaskListSearch taskListSearch)
        {
            var query = _context.Tasks
                .Include(x => x.Assigee).AsQueryable();

            if (!string.IsNullOrEmpty(taskListSearch.Name))
                query = query.Where(x => x.TaskName.Contains(taskListSearch.Name));

            if (taskListSearch.AssigneeId.HasValue)
                query = query.Where(x => x.AssigeeId == taskListSearch.AssigneeId.Value);

            if (taskListSearch.Priority.HasValue)
                query = query.Where(x => x.Priority == taskListSearch.Priority.Value);
            //if (taskListSearch.AssigneeId == null  && taskListSearch.Priority == null)
            //    query = query.Where(x => x.TaskName.Contains(taskListSearch.Name));


            return await query.OrderByDescending(x => x.CreateDate).ToListAsync();
        }

        //get_task by Id
        public async Task<Entities.Task> GetById(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }
        //CREATE_TASK
        public  async Task<Entities.Task> Create(Entities.Task task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }
       
        //DELETE_TASK
        public async Task<Entities.Task> Delete(Entities.Task task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return task;
        }

       

        public async Task<IEnumerable<Entities.Task>> GetTaskList()
        {
            return await _context.Tasks.ToListAsync();
        }

        //UPDATE_TASK
        public async Task<Entities.Task> Update(Entities.Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }
    }
}
