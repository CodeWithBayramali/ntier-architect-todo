using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy.TodoAppNTier.DataAccess.Interfaces;

namespace Udemy.TodoAppNTier.DataAccess.UnitOfWorks
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : class, new();
        Task SaveChanges();
    }
}