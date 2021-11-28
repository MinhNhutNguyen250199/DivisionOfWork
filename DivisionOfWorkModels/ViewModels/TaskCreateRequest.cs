
using DivisionOfWorkModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionOfWorkModels.ViewModels
{
        public class TaskCreateRequest
        {
        public int Id { get; set; }

        [MaxLength(40, ErrorMessage = "You cannot fill task name over than 40 characters")]
        [Required(ErrorMessage = "Please enter your task name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select your Task Priority")]
        public Priority? Priority { get; set; }
       
    }
    
}
