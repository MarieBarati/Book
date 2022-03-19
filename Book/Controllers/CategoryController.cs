using Book.Data;
using Book.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]//To Avoid Cross-site request forgery
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Check your information");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Add is Done!";
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFormDb = _db.Categories.Find(id);
            if(categoryFormDb == null)
            {
                return NotFound();
            } 

            return View(categoryFormDb);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]//To Avoid Cross-site request forgery
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Check your information");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Edit is Done!";
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFormDb = _db.Categories.Find(id);
            if (categoryFormDb == null)
            {
                return NotFound();
            }

            return View(categoryFormDb);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]//To Avoid Cross-site request forgery
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFormDb = _db.Categories.Find(id);
            if (categoryFormDb == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(categoryFormDb);
                _db.SaveChanges();
            TempData["success"] = "Delete is Done!";
                return RedirectToAction("Index");
        }
    }
}
