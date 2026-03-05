using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using webbantrasua.Models;
using webbantrasua.Repositories;

namespace webbantrasua.Controllers
{
    public class ProductController : Controller
    {
        // khởi tạo 2 đối tượng
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductController(IProductRepository productRepository,
 ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        // gọi giao diện
        public IActionResult Add()
        {
            var categories = _categoryRepository.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        // đẩy dữ liệu vào DB
        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Add(product);
                return RedirectToAction("Index"); // Chuyển hướng tới trang danh sách sản phẩm
            }
            return View(product);
        }

    }
}
