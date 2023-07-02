using Catalog.DB_Context;
using Catalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Catalog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FolderDbContext _context;

        public HomeController(ILogger<HomeController> logger, FolderDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<ActionResult> FolderPage(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return NotFound();
            }
            var folder = await _context.Folders.Include(f => f.Children).FirstOrDefaultAsync(f => f.Path == path);
            
            if (folder == null)
            {
                return NotFound();
            }

            return View(folder);
        }
    }
}