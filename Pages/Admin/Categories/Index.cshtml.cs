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
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;
        private readonly IUnitOfWork unitOfWork;
        public IEnumerable<CategoryModel> Categories;

        public Index(ILogger<Index> logger, IUnitOfWork _unitOfWork)
        {
            _logger = logger;
            unitOfWork = _unitOfWork;
        }

        public void OnGet()
        {
            Categories = unitOfWork.Category.GetAll();
        }
    }
}