using Microsoft.AspNetCore.Mvc;
using NFTMVCPROJECT.Models;
using NFTMVCPROJECT.Services;

namespace NFTMVCPROJECT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CollectionController : Controller
    {
        private readonly CollectionsService _service;

        public CollectionController()
        {
            _service = new CollectionsService();
        }


        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();


        }

        [HttpPost]
        public IActionResult Create(Collection collection)
        {
            _service.CreateCollection(collection);
            return RedirectToAction();


        }
        #endregion

        #region Read
        [HttpGet]
        public IActionResult Index()
        {
            List<Collection> collection = _service.GetAllCollection();
            return View(collection);
        }

        public IActionResult Info(int id)
        {
            Collection collection = _service.GetCollectionById(id);
            return View(collection);

        }
        #endregion

        #region Update
        [HttpGet]
        public IActionResult Update(int id)
        {
            Collection collection = _service.GetCollectionById(id);
            return View(collection);
        }
        [HttpPost]
        public IActionResult Update(int id, Collection collection)
        {
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Delete 
        [HttpGet]

        public IActionResult Delete(int id)
        {
            Collection collection = _service.GetCollectionById(id);
            return View(collection);
        }

        [HttpPost]
        [ActionName("Delete")]

        public IActionResult DeletePost(int id)
        {
            _service.DeleteCollection(id);
            return View();
        }
        #endregion
    }
}
