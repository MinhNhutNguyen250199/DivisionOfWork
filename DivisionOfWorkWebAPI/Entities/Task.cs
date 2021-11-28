using DivisionOfWorkModels.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DivisionOfWorkWebAPI.Entities
{
    public class Task
    {
        [Key]
        public int IdTask { get; set; }

        [MaxLength(250)]
        [Required] 
        public  string TaskName { get; set; }

        public int? AssigeeId { get; set; }

        [ForeignKey ("AssigeeId")]
        public User Assigee { get; set; }

       
        public DateTime CreateDate { get; set; }
        public Priority Priority { get; set; }
        public StatusTask StatusTask { get; set; }




    }
}
