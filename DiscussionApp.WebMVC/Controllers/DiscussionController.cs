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
        //FilmService filmService = new FilmService();
        //TelevisionService tvService = new TelevisionService();
        //SportService sportService = new SportService();

        // GET: Discussion
        // ---------------
        //[Route("")]
        public ActionResult Index()
        {
            // ------------------
            //var service = CreateDiscussionService();
            var service = new DiscussionService();
            var model = service.GetDiscussions();
            ViewBag.UserId = Guid.Parse(User.Identity.GetUserId());

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

            //ViewBag.FilmId = new SelectList(filmService.GetFilms(), "FilmId", "Title");
            //ViewBag.TelevisionId = new SelectList(tvService.GetTVShows(), "TelevisionId", "Title");
            //ViewBag.SportId = new SelectList(sportService.GetSports(), "SportId", "");

            return View();
        }

        // POST: Discussion/Create
        [HttpPost]
        // --------------------
        //[ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DiscussionCreate model)
        {
            // -------------------
            //model.DiscussionId = Guid.NewGuid();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // -------------------
            //var service = CreateDiscussionService();
            var service = new DiscussionService();

            if (service.CreateDiscussion(model))
            {
                TempData["SaveResult"] = "The discussion was created.";
                return RedirectToAction("Index");
                // ----------
                //return RedirectToAction("Index", "Post", new { discussionId = model.DiscussionId });
            };

            ModelState.AddModelError("", "The discussion could not be created.");
            //ViewBag.FilmId = new SelectList(filmService.GetFilms(), "FilmId", "Title");

            return View(model);
        }

        // GET: Discussion/Detail/{id}
        public ActionResult Details(int id)
        {
            var service = new DiscussionService();
            // -------------
            //var service = CreateDiscussionService();
            var model = service.GetDiscussionById(id);

            // -------------
            //ViewBag.Discussion = service.GetDiscussionTitle(id);

            return View(model);
        }

        // GET: Discussion/Edit/{id}
        public ActionResult Edit(int id)
        {
            // ------------
            //var service = CreateDiscussionService();
            DiscussionService service = new DiscussionService();
            FilmService filmService = new FilmService();

            var detail = service.GetDiscussionById(id);
            //var filmDetail = filmService.GetFilmById(filmId);

            var model = new DiscussionEdit
            {
                DiscussionId = detail.DiscussionId,
                FilmId = detail.FilmId,
                MediaType = detail.MediaType,
                DiscussionTitle = detail.DiscussionTitle,
                //Comment = detail.Comment,
                //Film = detail.Film,
                //TVShow = detail.TVShow,
                //Sport = detail.Sport
            };

            // ------------
            //ViewBag.Discussion = service.GetDiscussionTitle(id);
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

            // -------------
            //var service = CreateDiscussionService();
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
            // ------------
            //var service = CreateThreadService();
            var service = new DiscussionService();
            var model = service.GetDiscussionById(id);

            // ------------
            //ViewBag.Discussion = service.GetDiscussionTitle(id);

            return View(model);
        }

        // POST: Discussion/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDiscussion(int id)
        {
            // ------------
            //var service = CreateDiscussionService();

            var service = new DiscussionService();

            if (service.DeleteDiscussion(id))
            {
                return RedirectToAction("Index");
            }

            // ----- instead of if statement -------
            //service.DeleteDiscussion(id);

            TempData["SaveResult"] = "The discussion was deleted.";

            return RedirectToAction("Delete", new { id });
        }

        // ------------- Helper Method -------------------
        //private DiscussionService CreateDiscussionService()
        //{
        //    var userId = Guid.Parse(User.Identity.GetUserId());
        //    var service = new DiscussionService(userId);
        //    return service;
        //}
        // ------------------------------------------------

}
}