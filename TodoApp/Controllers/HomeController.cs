using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using TodoApp.Models;
using TodoApp.Entity;
using TodoApp.Service;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TodoService _todoService;
        private readonly CategoryService _categoryService;
        public HomeController(TodoService todoService, CategoryService categoryService)
        {
            _todoService = todoService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var listCategory = await _categoryService.GetAllCateogiriesService();
            var listTodo = await _todoService.GetAllTodosService();
            var vm = new TodoFormVM()
            {
                Categories = [.. listCategory],
                Todos = [.. listTodo],
                CategoriesOption = listCategory.Select(c => new SelectListItem()
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.Name

                }).ToList()
            };
            return View(vm);
        }

        // ---------- CATEGORY -------------

        // ADDING
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryVM category)
        {
            ViewBag.message = null;
            var vm = new TodoFormVM();
            if (!ModelState.IsValid) return View(vm);

            await _categoryService.AddCategoryService(category);
            var cleanCategory = new CategoryVM();

            ViewBag.message = "The category was created";
            return RedirectToAction("Index");
        }

        // DELETE CATEGORY
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(long id)
        {
            var listTodo = await _categoryService.HasTodos(id);
            if (listTodo)
            {
                TempData["Error"] = "Cannot delete category with tasks";

                return RedirectToAction("Index");

            }
            await _categoryService.DeleteCategoryService(id);
            return RedirectToAction("Index");
        }

        // ------------ TODO -------------
        // ADDING NEW TODO
        [HttpPost]
        public async Task<IActionResult> AddTodo(AddTodoVM todoItem)
        {
            ViewBag.message = null;
            var vm = new TodoFormVM();
            if (!ModelState.IsValid) return View("Index", vm);
            await _todoService.InsertTodoService(todoItem);
            var cleanTodo = new TodoFormVM();
            ViewBag.message = "The task was created";
            return RedirectToAction("Index");
        }

        // DELETE TODO
        [HttpPost]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            await _todoService.DeleteTodoService(id);
            return RedirectToAction("Index");
        }

        // EDIT TODO
        [HttpPost]
        public async Task<IActionResult> EditTodo(long id)
        {
            await _todoService.UpdateService(id);
            TempData["Message"] = "Your task was updated";
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
