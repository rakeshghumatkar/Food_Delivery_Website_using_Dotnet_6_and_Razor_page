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
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public IEnumerable<FoodDelivery.Models.FoodType> FoodType {get; set;}

        public Index(ILogger<Index> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            FoodType = _unitOfWork.FoodType.GetAll();
        }
    }
}