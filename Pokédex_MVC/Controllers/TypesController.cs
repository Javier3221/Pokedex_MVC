using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Application.ViewModels;

namespace Pokédex_MVC.Controllers
{
    public class TypesController : Controller
    {
        private readonly TypeService _typeService;

        public TypesController(ApplicationContext dbContext)
        {
            _typeService = new(dbContext);
        }
        public async Task<IActionResult> TypeList()
        {
            return View(await _typeService.GetAllViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(TypeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveType", vm);
            }

            await _typeService.Add(vm);
            return RedirectToRoute(new { controller = "Types", action = "TypeList" });
        }

        public IActionResult Create()
        {
            return View("SaveType", new TypeViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Update(TypeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveType", vm);
            }

            await _typeService.Update(vm);
            return RedirectToRoute(new { controller = "Types", action = "TypeList" });
        }

        public async Task<IActionResult> Update(int id)
        {
            return View("SaveType", await _typeService.GetByIdViewModel(id));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _typeService.Delete(id);
            return RedirectToRoute(new { controller = "Types", action = "TypeList" });
        }
    }
}
