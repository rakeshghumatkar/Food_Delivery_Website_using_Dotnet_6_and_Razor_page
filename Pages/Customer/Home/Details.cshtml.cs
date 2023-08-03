using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Data.IRepositoryDirectory;
using FoodDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FoodDelivery.Pages.Customer.Home
{
    public class Details : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public MenuItem MenuItem {get; set;}

        [BindProperty]
        [Range(1,100, ErrorMessage = "Please select the coun in the range 1 to 100")]
        public int Count {get; set;}

        public Details(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int? id)
        {
            MenuItem = _unitOfWork.MenuItem.GetFirstOrDefault(u=>u.Id == id, includeProperties : "CategoryModel,FoodType");
        }
    }
}