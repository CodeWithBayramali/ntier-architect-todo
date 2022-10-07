using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy.TodoAppNTier.Business.Interfaces;
using Udemy.TodoAppNTier.DataAccess.UnitOfWorks;
using Udemy.TodoAppNTier.Dtos.WorkDtos;
using Udemy.TodoAppNTier.Entities.Domains;

namespace Udemy.TodoAppNTier.Business.Services
{
    public class WorkService : IWorkService
    {
        private readonly IUow _uow;

        public WorkService(IUow uow)
        {
            _uow = uow;
        }

        public async Task Create(WorkCreateDTO dto)
        {
            await _uow.GetRepository<Work>().CreateAsync(new (){
                IsCompleted= dto.IsCompleted,
                Definition = dto.Definition
            });
            await _uow.SaveChanges();
        }

        public async Task<List<WorkListDTO>> GetAllAsync()
        {
            var list = await _uow.GetRepository<Work>().GetAllAsync();
            
            var workList = new List<WorkListDTO>();
            
            if(list != null && list.Count >0)
            {
                foreach (var work in list)
                {
                    workList.Add(new (){
                        Definition = work.Definition,
                        Id = work.Id,
                        IsCompleted = work.IsCompleted 
                    });
                }
            }
            return workList;
        }

        public async Task<WorkListDTO> GetByIdAsync(int id)
        {
           var work=await _uow.GetRepository<Work>().GetByFilterAsync(w=> w.Id == id);
           return new (){
            Definition = work.Definition,
            IsCompleted = work.IsCompleted
           };
        }

        public async Task Remove(object id)
        {
            var deletedWork = await _uow.GetRepository<Work>().GetByIdAsync(id);
            _uow.GetRepository<Work>().Remove(deletedWork);

            await _uow.SaveChanges();
        }

        public async Task Update(WorkUpdateDTO dto)
        {
            _uow.GetRepository<Work>().Update(new (){
                Definition = dto.Definition,
                Id=dto.Id,
                IsCompleted=dto.IsCompleted
            });

            await _uow.SaveChanges();
        }
    }
}