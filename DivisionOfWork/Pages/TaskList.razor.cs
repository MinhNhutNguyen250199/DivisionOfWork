using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DivisionOfWork.ServicesAPI;
using DivisionOfWorkModels.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;


namespace DivisionOfWork.Pages
{
    public partial class TaskList
    {
    

        private List<TaskDto> Tasks;

        private List<AssigneeDto> Assignees;

        private TaskListSearch TaskListSearch = new TaskListSearch();

        protected override async Task OnInitializedAsync()
        {
            Tasks = await TaskApiClient.GetTaskList(TaskListSearch);
            Assignees = await UserApiClient.GetAssignees();
        }

        private async Task SearchForm(EditContext context)
        {
            
            Tasks = await TaskApiClient.GetTaskList(TaskListSearch); 
        }
    }


}