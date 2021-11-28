using DivisionOfWorkModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DivisionOfWorkModels.ViewModels
{
    public class TaskDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? AssigneeId { get; set; }

        public string AssigneeName { set; get; }

        public DateTime CreatedDate { get; set; }

        public Priority Priority { get; set; }

        public StatusTask Status { get; set; }
    }
}
