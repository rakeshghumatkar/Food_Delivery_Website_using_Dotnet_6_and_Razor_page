using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Data.IRepositoryDirectory;
using FoodDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FoodDelivery.Pages.Customer.Home
{
    [BindProperties]
    public class Index : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<CategoryModel> CategoryList {get; set;}
        public IEnumerable<MenuItem> MenuItemList {get; set;}

        public Index(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            MenuItemList = _unitOfWork.MenuItem.GetAll(includeProperties : "CategoryModel,FoodType");
            CategoryList = _unitOfWork.Category.GetAll(orderby: u=>u.OrderBy(u=>u.DisplayOrder));
        }
    }
}