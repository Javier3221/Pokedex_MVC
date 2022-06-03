using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokédex_MVC.Controllers
{
    public class PokemonController : Controller
    {
        public IActionResult PokemonListView()
        {
            return View();
        }
    }
}
