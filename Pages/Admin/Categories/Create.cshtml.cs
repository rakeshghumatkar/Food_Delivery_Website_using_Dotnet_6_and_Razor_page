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
    public class Create : PageModel
    {
        private readonly ILogger<Create> _logger;
        private readonly IUnitOfWork unitOfWork;
        [BindProperty]
        public CategoryModel category {get; set;}

        public Create(ILogger<Create> logger, IUnitOfWork _unitOfWork)
        {
            _logger = logger;
            unitOfWork = _unitOfWork;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("category.Name", "Name and Display Order can not be same");
            }
            if(ModelState.IsValid)
            {
                unitOfWork.Category.Add(category);
                unitOfWork.Save();
                TempData["success"] = "New Category has created successfully!";
                return RedirectToPage("Index");
            }
            return Page();
        }
    
    }
}