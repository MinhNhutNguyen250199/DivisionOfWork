using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DivisionOfWorkWebAPI.Entities
{
    public class Role :IdentityRole<int>
    {
        [MaxLength(250)]
        [Required]
        public String Description { get; set; }

    }
}
