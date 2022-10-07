using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Udemy.TodoAppNTier.Business.Interfaces;
using Udemy.TodoAppNTier.Dtos.WorkDtos;

namespace Udemy.TodoAppNTier.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWorkService _workService;

        public HomeController(ILogger<HomeController> logger, IWorkService workService)
        {
            _logger = logger;
            _workService = workService;
        }

        public async Task<IActionResult> Index()
        {
            var workList = await _workService.GetAllAsync();
            return View(workList);
        }

        public IActionResult Create()
        {
            return View(new WorkCreateDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDTO dto)
        {
            if (ModelState.IsValid)
            {
                await _workService.Create(dto);
                return RedirectToAction("Index");
            }
            return View(dto);
        }

        public async Task<IActionResult> Update([FromRoute] int id)
        {
            var updateData= await _workService.GetByIdAsync(id);

            return View(new WorkUpdateDTO(){
                Definition = updateData.Definition,
                IsCompleted= updateData.IsCompleted,
                Id = updateData.Id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDTO dto)
        {
            if(ModelState.IsValid)
            {
                await _workService.Update(dto);
                return RedirectToAction("Index");
            }
            return View(dto);
        }

        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            await _workService.Remove(id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}