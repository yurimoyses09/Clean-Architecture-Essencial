using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace CleanArchMvc.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategotyService _categoryService;
        public CategoriesController(ICategotyService categotyService)
        {
            _categoryService = categotyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetCategories());
        }
    }
}
