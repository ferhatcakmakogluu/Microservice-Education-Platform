using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineCourse.Shared.Services;
using OnlineCourse.Web.Models.Catalog;
using OnlineCourse.Web.Services.Interfaces;
using System.Threading.Tasks;

namespace OnlineCourse.Web.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly ISharedIdentityService _identityService;

        public CoursesController(ICatalogService catalogService, ISharedIdentityService identityService)
        {
            _catalogService = catalogService;
            _identityService = identityService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _catalogService.GetAllCourseByUserIdAsync(_identityService.GetUserId));
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _catalogService.GetAllCategoryAsync();
            ViewBag.categoryList = new SelectList(categories, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateInput courseCreateInput)
        {
            var categories = await _catalogService.GetAllCategoryAsync();
            ViewBag.categoryList = new SelectList(categories, "Id", "Name");
            if (!ModelState.IsValid)
            {
                return View();
            }

            courseCreateInput.UserId = _identityService.GetUserId;
            await _catalogService.CreateCourseAsync(courseCreateInput);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(string id)
        {
            var course = await _catalogService.GetByCourseIdAsync(id);

            if (course == null)
            {
                RedirectToAction(nameof(Index));
            }

            var categories = await _catalogService.GetAllCategoryAsync();
            ViewBag.categoryList = new SelectList(categories, "Id", "Name", course.Id);

            CourseUpdateInput courseUpdateInput = new()
            {
                Id = course.Id,
                Name = course.Name,
                Picture = course.Picture,
                Description = course.Description,
                Feature = course.Feature,
                Price = course.Price,
                CategoryId = course.CategoryId,
                UserId = course.UserId
            };

            return View(courseUpdateInput);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CourseUpdateInput courseUpdateInput)
        {
            var categories = await _catalogService.GetAllCategoryAsync();
            ViewBag.categoryList = new SelectList(categories, "Id", "Name", courseUpdateInput.Id);
            
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _catalogService.UpdateCourseAsync(courseUpdateInput);

            return RedirectToAction(nameof(Index));
        }
    }
}
