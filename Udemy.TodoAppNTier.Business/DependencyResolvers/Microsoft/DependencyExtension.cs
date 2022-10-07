using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Udemy.TodoAppNTier.Business.Interfaces;
using Udemy.TodoAppNTier.Business.Services;
using Udemy.TodoAppNTier.DataAccess.Contexts;
using Udemy.TodoAppNTier.DataAccess.UnitOfWorks;

namespace Udemy.TodoAppNTier.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUow,Uow>();
            services.AddScoped<IWorkService,WorkService>();
            services.AddDbContext<TodoContext>(opt=> {
                opt.UseSqlite("Data Source=TodoDb");
                opt.LogTo(Console.WriteLine,LogLevel.Information);
            });
        }
    }
}