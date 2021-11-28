using DivisionOfWorkModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionOfWorkModels.ViewModels
{
    public class TaskListSearch
    {
        public string Name { get; set; }

        public int? AssigneeId { get; set; }

        public Priority? Priority { get; set; }
    }
}
