using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Udemy.TodoAppNTier.Dtos.WorkDtos
{
    public class WorkCreateDTO
    {
        [Required(ErrorMessage = "Definition is required")]
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}