using DivisionOfWorkModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivisionOfWork.ServicesAPI
{
    public interface IShow
    {
        Task<List<TaskDto>> GetTaskList();
    }
}
