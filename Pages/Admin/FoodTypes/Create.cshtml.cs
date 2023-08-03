using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Data.IRepositoryDirectory;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FoodDelivery.Pages.Admin.FoodTypes
{
    public class Create : PageModel
    {
        private readonly ILogger<Create> _logger;
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public FoodDelivery.Models.FoodType foodType{get; set;}

        public Create(ILogger<Create> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int? id)
        {
            foodType = _unitOfWork.FoodType.GetFirstOrDefault(x=>x.Id==id);
            
        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.FoodType.Add(foodType);
                _unitOfWork.Save();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}