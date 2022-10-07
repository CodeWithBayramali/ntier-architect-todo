using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Udemy.TodoAppNTier.Dtos.WorkDtos
{
    public class WorkListDTO
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}