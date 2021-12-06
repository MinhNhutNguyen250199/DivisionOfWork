using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Json;
using DivisionOfWork.ServicesAPI;
using DivisionOfWorkModels.ViewModels;

namespace DivisionOfWork.ServicesAPI
{
    public class Show : IShow
    {
        public HttpClient _httpClient;

        public Show(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TaskDto>> GetTaskList()
        {
            var result = await _httpClient.GetFromJsonAsync<List<TaskDto>>("/api/Task");
            return result;
        }
    }
}
