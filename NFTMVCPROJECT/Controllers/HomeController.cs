using Microsoft.AspNetCore.Mvc;
using NFTMVCPROJECT.Models;
using NFTMVCPROJECT.Services;

namespace NFTMVCPROJECT.Controllers
{
    public class HomeController : Controller
    {
        private readonly CollectionsService _collectionService;
        public HomeController()
        {
            _collectionService = new CollectionsService();
        }

        public IActionResult Index()
        {
            List<Collection> collections = _collectionService.GetAllCollection();
            //CollectionVM collectionVM = new CollectionVM()
            //{
            //    Id = 1,

            //};


            return View(collections);
        }
    }
}
