using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Data.IRepositoryDirectory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace FoodDelivery.Pages.Admin.MenuItems
{
    [BindProperties]
    public class Upsert : PageModel
    {
        private readonly ILogger<Upsert> _logger;

        private readonly IUnitOfWork _unitOfWork ;

        private IWebHostEnvironment _webHostEnvironment ;

        public FoodDelivery.Models.MenuItem menuItem {get; set;}

        public IEnumerable<SelectListItem> CategoryList {get; set;}
        public IEnumerable<SelectListItem> FoodTypeList {get; set;}
        public Upsert(ILogger<Upsert> logger, IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            menuItem = new();
            _webHostEnvironment = webHostEnvironment;
        }

        public void OnGet(int? id)
        {
            //Edit request
            if(id!=null)
            {
                menuItem = _unitOfWork.MenuItem.GetFirstOrDefault(x=>x.Id==id);
            }
            CategoryList = _unitOfWork.Category.GetAll().Select(u=>new SelectListItem(){
                Text = u.Name,
                Value = u.Id.ToString()
            });

            FoodTypeList = _unitOfWork.FoodType.GetAll().Select(u => new SelectListItem(){
                Text = u.Name,
                Value = u.Id.ToString()
            });
        }

        public async Task<IActionResult> OnPost()
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            if(menuItem.Id == 0)
            {
                //create
                string fileName_new = Guid.NewGuid().ToString();
                var upload = Path.Combine(webRootPath, @"images\menuItems");
                var extension = Path.GetExtension(files[0].FileName);
                using(var filestream = new FileStream(Path.Combine(upload, fileName_new + extension), FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                }
                menuItem.Image = @"\images\menuItems\" + fileName_new + extension ;

                _unitOfWork.MenuItem.Add(menuItem);
                _unitOfWork.Save();
                return RedirectToPage("Index");
            }
            else
            {
                //edit
                var objFromDb = _unitOfWork.MenuItem.GetFirstOrDefault(x=>x.Id == menuItem.Id);
                if(files.Count>0)
                {
                    string fileName_new = Guid.NewGuid().ToString();
                    var upload = Path.Combine(webRootPath, @"images\menuItems");
                    var extension = Path.GetExtension(files[0].FileName);
                    //delete the old image
                    var oldImage = Path.Combine(webRootPath,objFromDb.Image.TrimStart('\\'));
                    if(System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }
                    //upload new image
                    using(var filestream = new FileStream(Path.Combine(upload, fileName_new + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    menuItem.Image = @"\images\menuItems\" + fileName_new + extension ;

                }
                else{
                    menuItem.Image = objFromDb.Image;
                }

                _unitOfWork.MenuItem.Update(menuItem);
                _unitOfWork.Save();

            }
            return RedirectToPage("./Index");
        }
    }
}