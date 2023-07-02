using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Catalog.DB_Context;
using Catalog.Models;

namespace Catalog.Controllers
{
    public class ExportController : Controller
    {
        private readonly FolderDbContext _folderDbContext;
        public ExportController(FolderDbContext folderDbContext)
        {
            _folderDbContext = folderDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Export()
        {
            List<FolderModel> folders = _folderDbContext.Folders.ToList();

            string json = JsonConvert.SerializeObject(folders);

            byte[] bytes = Encoding.UTF8.GetBytes(json);

            return File(bytes, "application/json", "database.json");
        }

    }
}
