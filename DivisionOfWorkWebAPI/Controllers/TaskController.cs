using DivisionOfWorkModels.Enums;
using DivisionOfWorkModels.ViewModels;
using DivisionOfWorkWebAPI.Reponsitories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivisionOfWorkWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskrepository)
        {
            _taskRepository = taskrepository;
        }

        //api/tasks?name=
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] TaskListSearch taskListSearch)
        {
            var tasks = await _taskRepository.GetTaskList(taskListSearch);
            var taskDtos = tasks.Select(x => new TaskDto()
            {
                Status = x.StatusTask,
                Name = x.TaskName,
                AssigneeId = x.AssigeeId,
                CreatedDate = x.CreateDate,
                Priority = x.Priority,
                Id = x.IdTask,
                AssigneeName = x.Assigee != null ? x.Assigee.FirstName + ' ' + x.Assigee.LastName : "N/A"
            });

            return Ok(taskDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = await _taskRepository.Create(new Entities.Task()
            {
                TaskName = request.Name,
                Priority = request.Priority.HasValue ? request.Priority.Value : Priority.Low,
                StatusTask = StatusTask.Open,
                CreateDate = DateTime.Now,
                IdTask = request.Id,
           

            }); 
            return CreatedAtAction(nameof(GetById), new { id = task.IdTask }, task);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] TaskUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var taskFromDb = await _taskRepository.GetById(id);

            if (taskFromDb == null)
            {
                return NotFound($"{id} is not found");
            }

            taskFromDb.TaskName = request.Name;
            taskFromDb.Priority = request.Priority;

            var taskResult = await _taskRepository.Update(taskFromDb);

            return Ok(new TaskDto()
            {
                Name = taskResult.TaskName,
                Status = taskResult.StatusTask,
                Id = taskResult.IdTask,
                AssigneeId = taskResult.AssigeeId,
                Priority = taskResult.Priority,
                CreatedDate = taskResult.CreateDate
            });
        }

        //api/Task/xxxx
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var task = await _taskRepository.GetById(id);
            if (task == null) return NotFound($"{id} is not found");
            return Ok(new TaskDto()
            {
                Name = task.TaskName,
                Status = task.StatusTask,
                Id = task.IdTask,
                AssigneeId = task.AssigeeId,
                Priority = task.Priority,
                CreatedDate = task.CreateDate
            });
        }

        [HttpPut]
        [Route("{id}/assign")]
        public async Task<IActionResult> AssignTask(int id, [FromBody] AssignTaskRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var taskFromDb = await _taskRepository.GetById(id);

            if (taskFromDb == null)
            {
                return NotFound($"{id} is not found");
            }

            taskFromDb.AssigeeId = request.UserId.Value;
            var taskResult = await _taskRepository.Update(taskFromDb);

            return Ok(new TaskDto()
            {
                Name = taskResult.TaskName,
                Status = taskResult.StatusTask,
                Id = taskResult.IdTask,
                AssigneeId = taskResult.AssigeeId,
                Priority = taskResult.Priority,
                CreatedDate = taskResult.CreateDate
            });
        }


    }
}
