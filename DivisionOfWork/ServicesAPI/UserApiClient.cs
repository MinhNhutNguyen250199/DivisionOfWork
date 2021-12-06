using DivisionOfWorkModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DivisionOfWork.ServicesAPI
{
    public class UserApiClient : IUSerAPIClient
    {
        public HttpClient _httpClient;

        public UserApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AssigneeDto>> GetAssignees()
        {
            var result = await _httpClient.GetFromJsonAsync<List<AssigneeDto>>($"/api/User");
            return result;
        }
    }
}
