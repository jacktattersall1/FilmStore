using FilmStore.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmStore.Portal.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult List()
        {
            EfFilmRepository repo = new EfFilmRepository();
            return View(repo.SelectAll());
        }

        public ActionResult Details(int id)
        {
            EfFilmRepository repo = new EfFilmRepository();
            return View(repo.SelectById(id));
        }

        public ActionResult Delete(int id)
        {
            EfFilmRepository repo = new EfFilmRepository();
            repo.Delete(repo.SelectById(id));
            return RedirectToAction("List");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film newFilm)
        {
            if (ModelState.IsValid)
            {
                EfFilmRepository repo = new EfFilmRepository();
                repo.Insert(newFilm);

                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        public ActionResult Edit(Film film)
        {

        }

    }
}