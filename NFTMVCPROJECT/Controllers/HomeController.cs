using Microsoft.AspNetCore.Mvc;
using NFTMVCPROJECT.Contexts;

namespace NFTMVCPROJECT.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController()
        {
            _context = new AppDbContext();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
