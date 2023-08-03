using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Data.IRepositoryDirectory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FoodDelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork ;
        private readonly ILogger<MenuItemController> _logger;
        private IWebHostEnvironment _webHostEnvironment ;
        public MenuItemController(ILogger<MenuItemController> logger, IUnitOfWork unitOfWork,IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork =unitOfWork;
            _logger = logger;
            _webHostEnvironment =webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var menuItemsList = _unitOfWork.MenuItem.GetAll(includeProperties: "CategoryModel,FoodType");
            return Json(new {data = menuItemsList});
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.MenuItem.GetFirstOrDefault(x=>x.Id == id);
            //delete image
            if(System.IO.File.Exists(objFromDb.Image))
            {
                var deleteimage = Path.Combine(_webHostEnvironment.WebRootPath, objFromDb.Image.TrimStart('\\'));
                System.IO.File.Delete(deleteimage);
            }
            _unitOfWork.MenuItem.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success= true, message="deleted successfully"});
        }


    }
}