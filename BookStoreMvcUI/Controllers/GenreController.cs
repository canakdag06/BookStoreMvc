using Microsoft.AspNetCore.Mvc;
using BookStoreMvcUI.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;

namespace BookStoreMvcUI.Controllers
{
    public class GenreController : Controller
    {
        private readonly ApplicationDbContext _db;

        public GenreController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var models = _db.Genres.ToList();
            return View(models);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var model = _db.Genres.Find(id);
            return View(model);
        }

        public IActionResult Save(Genre model)
        {
            if (!model.GenreName.IsNullOrEmpty())
            {
                if(model.Id == 0)
                {
                    _db.Genres.Add(model);
                }
                else
                {
                    _db.Genres.Update(model);
                }
                _db.SaveChanges();
                TempData["success"] = "Yeni Tür Başarıyla Kaydedildi";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Tür Kaydedilemedi";
            return View("Create",model);
        }


        public IActionResult Delete(int id)
        {
            var model = _db.Genres.Find(id);
            _db.Genres.Remove(model);
            _db.SaveChanges();

            TempData["success"] = "Tür Silindi";
            return RedirectToAction("Index");
        }
    }
}
