using DivisionOfWorkModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DivisionOfWork.ServicesAPI
{
    public class TaskAPIClient : ITaskAPiClient
    {
        public HttpClient _httpClient;
        public TaskAPIClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateTask(TaskCreateRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/Task", request);
            return result.IsSuccessStatusCode;
        }

        public async Task<TaskDto> GetTaskDetail(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<TaskDto>($"/api/Task/{id}");
            return result;
        }

        public async Task<List<TaskDto>> GetTaskList(TaskListSearch taskListSearch)
        {
            string url = $"/api/Task?name={taskListSearch.Name}&assigneeId={taskListSearch.AssigneeId}&priority={taskListSearch.Priority}";
            var result = await _httpClient.GetFromJsonAsync<List<TaskDto>>(url);
            return result;
        }

        public async Task<bool> UpdateTask(int id, TaskUpdateRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/Task/{id}", request);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> AssignTask(int id, AssignTaskRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/Tasks/{id}/assign", request);
            return result.IsSuccessStatusCode;
        }
    }
}
