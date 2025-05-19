using Microsoft.AspNetCore.Mvc;
using NFTMVCPROJECT.Contexts;
using NFTMVCPROJECT.Models;

namespace NFTMVCPROJECT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        public DashboardController()
        {
            _context = new AppDbContext();
        }
        public IActionResult Index()
        {
            //List<Collection> collections= _context.collections.ToList();
            return View();
        }
    }
}
