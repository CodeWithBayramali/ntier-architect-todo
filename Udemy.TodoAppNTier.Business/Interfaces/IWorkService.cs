using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy.TodoAppNTier.Dtos.WorkDtos;

namespace Udemy.TodoAppNTier.Business.Interfaces
{
    public interface IWorkService
    {
        Task<List<WorkListDTO>> GetAllAsync();

        Task Create(WorkCreateDTO dto);

        Task<WorkListDTO> GetByIdAsync(int id);

        Task Remove(object id);

        Task Update(WorkUpdateDTO dto);
    }
}