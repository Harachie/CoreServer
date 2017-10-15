using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreServer.Models;
using CoreServer.Code;

namespace CoreServer.Controllers
{
    public class RootController : Controller
    {
        [HttpGet("")]
        public async Task<RedirectResult> InitializeMapAsync()
        {
            string newMapName = "newMap";

            await Repository.Rethink.CreateTableAsync(newMapName);

            return Redirect("/" + newMapName);
        }

        [HttpGet("{mapName}")]
        public ViewResult OpenMap(string mapName)
        {
            ViewData["Title"] = "MapView";

            return View("MapView", new ApiAnswer());
        }
    }
}