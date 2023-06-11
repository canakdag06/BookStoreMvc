using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BookStoreMvcUI.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var models = _db.Books.ToList();
            return View(models);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var model = _db.Books.Find(id);
            return View(model);
        }

        public IActionResult Save(Book model)
        {
            if (!model.BookName.IsNullOrEmpty())
            {
                if (model.Id == 0)
                {
                    _db.Books.Add(model);
                }
                else
                {
                    _db.Books.Update(model);
                }
                _db.SaveChanges();
                TempData["success"] = "Kitap Kaydedildi";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Kitap Kaydedilemedi";
            return View("Create", model);
        }

        public IActionResult Delete(int id)
        {
            var model = _db.Books.Find(id);
            _db.Books.Remove(model);
            _db.SaveChanges();

            TempData["success"] = "Kitap Silindi";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UploadImage(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                // Resmin kaydedileceği klasör yolu
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                // Resmin başarıyla yüklendiği mesajı veya diğer işlemleri yapabilirsiniz
                //return RedirectToAction("Index");
            }

            // Resim yüklenmediyse veya hatalıysa hata mesajını gösterebilir veya işlem yapabilirsiniz
            return View();
        }
    }
}
