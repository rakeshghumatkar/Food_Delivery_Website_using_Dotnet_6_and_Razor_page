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
    public class Edit : PageModel
    {
        private readonly ILogger<Edit> _logger;
        private readonly IUnitOfWork unitOfWork;

        [BindProperty]
        public CategoryModel category {get; set;}

        public Edit(ILogger<Edit> logger, IUnitOfWork _unitOfWork)
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
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("category.Name", "Name and Display Order can not be same");
            }

            if(ModelState.IsValid)
            {
                unitOfWork.Category.Update(category);
                unitOfWork.Save();
                TempData["success"] = "Category has updated successfully!";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}