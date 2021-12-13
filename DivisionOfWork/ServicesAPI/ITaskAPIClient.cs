using DivisionOfWorkModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivisionOfWork.ServicesAPI
{
    public interface ITaskAPiClient
    {
        Task<List<TaskDto>> GetTaskList(TaskListSearch taskListSearch);

        Task<TaskDto> GetTaskDetail(string id);
        Task<bool> CreateTask(TaskCreateRequest request);
        Task<bool> UpdateTask(int id, TaskUpdateRequest request);
        Task<bool> AssignTask(int id, AssignTaskRequest request);

    }
}
