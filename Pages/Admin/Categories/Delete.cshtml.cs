using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Data.IRepositoryDirectory;
using FoodDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FoodDelivery.Pages.Admin.Categories
{
    public class Delete : PageModel
    {
        private readonly ILogger<Delete> _logger;
        private readonly IUnitOfWork unitOfWork;

        [BindProperty]
        public CategoryModel category {get; set;}

        public Delete(ILogger<Delete> logger, IUnitOfWork _unitOfWork)
        {
            _logger = logger;
            unitOfWork = _unitOfWork;
        }

        public void OnGet(int? id)
        {
            category = unitOfWork.Category.GetFirstOrDefault(x=>x.Id==id);
        }

        public async Task<IActionResult> OnPost()
        {

            if(ModelState.IsValid)
            {
                unitOfWork.Category.Remove(category);
                unitOfWork.Save();
                TempData["success"] = "Category has deleted successfully!";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}