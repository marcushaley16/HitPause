using DiscussionApp.Data;
using DiscussionApp.Models;
using DiscussionApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiscussionApp.WebMVC.Controllers
{
    [Authorize]
    public class DiscussionController : Controller
    {
        FilmService filmService = new FilmService();
        TelevisionService tvService = new TelevisionService();
        SportService sportService = new SportService();

        // GET: Discussion
        public ActionResult Index()
        {
            var service = new DiscussionService();
            var model = service.GetDiscussions();

            return View(model);
        }

        // GET: Discussion/Create
        public ActionResult Create()
        {
            //FilmService filmService = new FilmService();
            //TelevisionService tvService = new TelevisionService();
            //SportService sportService = new SportService();

            //if ()
            //{
                
            //}
            //else if ()
            //{
                
            //}
            //else
            //{
                
            //}

            ViewBag.FilmId = new SelectList(filmService.GetFilms(), "FilmId", "Title");
            ViewBag.TelevisionId = new SelectList(tvService.GetTVShows(), "TelevisionId", "Title");
            ViewBag.SportId = new SelectList(sportService.GetSports(), "SportId", "");

            return View();
        }

        // POST: Discussion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DiscussionCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new DiscussionService();

            if (service.CreateDiscussion(model))
            {
                TempData["SaveResult"] = "The discussion was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");
            //ViewBag.FilmId = new SelectList(filmService.GetFilms(), "FilmId", "Title");
            return View(model);
        }

        // GET: Discussion/Detail/{id}
        public ActionResult Details(int id)
        {
            var service = new DiscussionService();
            var model = service.GetDiscussionById(id);

            return View(model);
        }

        // GET: Discussion/Edit/{id}
        public ActionResult Edit(int id)
        {
            DiscussionService service = new DiscussionService();
            FilmService filmService = new FilmService();

            var detail = service.GetDiscussionById(id);
            //var filmDetail = filmService.GetFilmById(filmId);

            var model = new DiscussionEdit
            {
                //DiscussionId = detail.DiscussionId,
                FilmId = detail.FilmId,
                MediaType = detail.MediaType,
                Title = detail.Title,
                Comment = detail.Comment,
                //Film = detail.Film,
                //TVShow = detail.TVShow,
                //Sport = detail.Sport
            };

            ViewBag.FilmId = new SelectList(filmService.GetFilms(), "FilmId", "Title", detail.FilmId);
            return View(model);
        }

        // POST: Discussion/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DiscussionEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.DiscussionId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new DiscussionService();

            if (service.UpdateDiscussion(model))
            {
                TempData["SaveResult"] = "The discussion was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The discussion could not be updated.");
            return View();
        }

        // GET: Discussion/Delete/{id}
        public ActionResult Delete(int id)
        {
            var service = new DiscussionService();
            var model = service.GetDiscussionById(id);

            return View(model);
        }

        // POST: Discussion/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDiscussion(int id)
        {
            var service = new DiscussionService();

            if (service.DeleteDiscussion(id))
            {
                return RedirectToAction("Index");
            }

            TempData["SaveResult"] = "The discussion was deleted.";

            return RedirectToAction("Delete", new { id });
        }
    }
}