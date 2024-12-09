using BookLibraryWeb.Database;
using BookLibraryWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly BookLibraryDbContext _db;

        public CategoryController(BookLibraryDbContext db)
        {
            _db = db;            
        }
        public IActionResult Index()
        {
            //var catList = _db.Categories.ToList();
            // IEnumerable is more prefered to 'var', because you woukd not need to add to list. 
            // It is already a list.
            IEnumerable<Category> catList = _db.Categories;
            return View(catList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder can not match the name");
            //    //ModelState.AddModelError("All", "The DisplayOrder can not match the name");
            //}
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            { 
                return View();
            }
            var categoryEdit  = _db.Categories.Find(id);
            //var categoryFirst = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (categoryEdit == null)
            {
                return NotFound();
            }
            return View(categoryEdit);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder can not match the name");
            //    //ModelState.AddModelError("All", "The DisplayOrder can not match the name");
            //}
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return View();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFirst = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder can not match the name");
            //    //ModelState.AddModelError("All", "The DisplayOrder can not match the name");
            //}
            if (ModelState.IsValid)
            {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
