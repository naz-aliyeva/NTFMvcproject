using Microsoft.AspNetCore.Mvc;
using NFTMVCPROJECT.Contexts;
using NFTMVCPROJECT.Models;
using NFTMVCPROJECT.Services;
using NFTMVCPROJECT.View_Models;
using System.ComponentModel;
using System.Drawing.Design;

namespace NFTMVCPROJECT.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly CollectionsService _collectionService ;
        public HomeController()
        {
            _collectionService = new CollectionsService();
        }

        public IActionResult Index()
        {
            List<Collection>  collections= _collectionService.GetAllCollection();
            //CollectionVM collectionVM = new CollectionVM()
            //{
            //    Id = 1,
                
            //};


            return View(collections);
        }
    }
}
