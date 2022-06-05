using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;

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
    }
}
