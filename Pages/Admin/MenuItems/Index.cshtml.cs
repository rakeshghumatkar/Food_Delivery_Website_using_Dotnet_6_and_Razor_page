using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Data.IRepositoryDirectory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FoodDelivery.Pages.Admin.MenuItems
{
    public class Index : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<Index> _logger;

        [BindProperty]
        public IEnumerable<FoodDelivery.Models.MenuItem> menuItems {get; set;}

        public Index(ILogger<Index> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            menuItems = _unitOfWork.MenuItem.GetAll();
        }
    }
}