using DiscussionApp.Contracts;
using DiscussionApp.Data;
using DiscussionApp.Models;
using DiscussionApp.Services;
using DiscussionApp.WebMVC.Data;
using Microsoft.AspNet.Identity;
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
        [Route("")]
        public ActionResult Index()
        {
            var service = NewDiscussionService();
            var model = service.GetDiscussions();

            ViewBag.UserId = Guid.Parse(User.Identity.GetUserId());

            return View(model);
        }

        // GET: FilmDiscussions
        [Route("")]
        public ActionResult IndexFilm()
        {
            var service = NewDiscussionService();
            var model = service.GetDiscussionsByType(MediaType.Film);

            ViewBag.UserId = Guid.Parse(User.Identity.GetUserId());

            return View(model);
        }

        // GET: TelevisionDiscussions
        [Route("")]
        public ActionResult IndexTelevision()
        {
            var service = NewDiscussionService();
            var model = service.GetDiscussionsByType(MediaType.Television);

            ViewBag.UserId = Guid.Parse(User.Identity.GetUserId());

            return View(model);
        }

        // GET: SportDiscussions
        [Route("")]
        public ActionResult IndexSport()
        {
            var service = NewDiscussionService();
            var model = service.GetDiscussionsByType(MediaType.Sports);

            ViewBag.UserId = Guid.Parse(User.Identity.GetUserId());

            return View(model);
        }

        // GET: Discussion/Create
        public ActionResult CreateFilmDiscussion()
        {
            ViewBag.FilmId = new SelectList(filmService.GetFilms(), "FilmId", "Title");

            return View();
        }

        public ActionResult CreateTelevisionDiscussion()
        {
            ViewBag.TelevisionId = new SelectList(tvService.GetTVShows(), "TelevisionId", "Title");

            return View();
        }

        public ActionResult CreateSportDiscussion()
        {
            ViewBag.SportId = new SelectList(sportService.GetSports(), "SportId", "League");
            ViewBag.Matchup = new SelectList(sportService.GetSports(), "SportId", "Matchup");

            return View();
        }

        // POST: FilmDiscussion/Create
        [HttpPost]
        [ActionName("CreateFilmDiscussion")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFilmDiscussion(FilmDiscussionCreate model)
        {
            model.DiscussionId = Guid.NewGuid();

            model.MediaType = MediaType.Film;

            var service = NewDiscussionService();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.SportId = 1;
            model.TelevisionId = 1;

            if (service.CreateDiscussion(model))
            {
                TempData["ResultSaved"] = "The discussion was created.";
                return RedirectToAction("Index", "Post", new { discussionId = model.DiscussionId });
            };

            ModelState.AddModelError("", "The discussion could not be created.");

            return View(model);
        }

        // POST: TelevisionDiscussion/Create
        [HttpPost]
        [ActionName("CreateTelevisionDiscussion")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTelevisionDiscussion(TelevisionDiscussionCreate model)
        {
            model.DiscussionId = Guid.NewGuid();

            model.MediaType = MediaType.Television;

            var service = NewDiscussionService();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.FilmId = 1;
            model.SportId = 1;

            if (service.CreateDiscussion(model))
            {
                TempData["ResultSaved"] = "The discussion was created.";
                return RedirectToAction("Index", "Post", new { discussionId = model.DiscussionId });
            };

            ModelState.AddModelError("", "The discussion could not be created.");

            return View(model);
        }

        // POST: SportDiscussion/Create
        [HttpPost]
        [ActionName("CreateSportDiscussion")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSportDiscussion(SportDiscussionCreate model)
        {
            model.DiscussionId = Guid.NewGuid();

            model.MediaType = MediaType.Sports;

            var service = NewDiscussionService();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.FilmId = 1;
            model.TelevisionId = 1;

            if (service.CreateDiscussion(model))
            {
                TempData["ResultSaved"] = "The discussion was created.";
                return RedirectToAction("Index", "Post", new { discussionId = model.DiscussionId });
            };

            ModelState.AddModelError("", "The discussion could not be created.");

            return View(model);
        }

        // GET: Discussion/Detail/{id}
        public ActionResult Details(Guid id)
        {
            var service = NewDiscussionService();
            var model = service.GetDiscussionById(id);

            ViewBag.Discussion = service.GetDiscussionTitle(id);

            return View(model);
        }

        // GET: Discussion/Edit/{id}
        public ActionResult EditFilmDiscussion(Guid id)
        {
            var service = NewDiscussionService();

            var detail = service.GetDiscussionById(id);

            var model = new DiscussionEdit
            {
                DiscussionId = detail.DiscussionId,
                FilmId = detail.FilmId,
                TelevisionId = detail.TelevisionId,
                SportId = detail.SportId,
                MediaType = detail.MediaType,
                DiscussionTitle = detail.DiscussionTitle,
            };

            ViewBag.Discussion = service.GetDiscussionTitle(id);
            ViewBag.FilmId = new SelectList(filmService.GetFilms(), "FilmId", "Title", detail.FilmId);
            return View(model);
        }

        // GET: Discussion/Edit/{id}
        public ActionResult EditTelevisionDiscussion(Guid id)
        {
            var service = NewDiscussionService();

            var detail = service.GetDiscussionById(id);

            var model = new DiscussionEdit
            {
                DiscussionId = detail.DiscussionId,
                FilmId = detail.FilmId,
                TelevisionId = detail.TelevisionId,
                SportId = detail.SportId,
                MediaType = detail.MediaType,
                DiscussionTitle = detail.DiscussionTitle,
            };

            ViewBag.Discussion = service.GetDiscussionTitle(id);
            ViewBag.TelevisionId = new SelectList(tvService.GetTVShows(), "TelevisionId", "Title", detail.TelevisionId);
            return View(model);
        }

        // GET: Discussion/Edit/{id}
        public ActionResult EditSportDiscussion(Guid id)
        {
            var service = NewDiscussionService();

            var detail = service.GetDiscussionById(id);

            var model = new DiscussionEdit
            {
                DiscussionId = detail.DiscussionId,
                FilmId = detail.FilmId,
                TelevisionId = detail.TelevisionId,
                SportId = detail.SportId,
                MediaType = detail.MediaType,
                DiscussionTitle = detail.DiscussionTitle,
            };

            ViewBag.Discussion = service.GetDiscussionTitle(id);
            ViewBag.SportId = new SelectList(sportService.GetSports(), "SportId", "Matchup", detail.SportId);
            return View(model);
        }

        // PUT: FilmDiscussion/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFilmDiscussion(Guid id, DiscussionEdit model)
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

            var service = NewDiscussionService();

            if (service.UpdateFilmDiscussion(model))
            {
                TempData["ResultSaved"] = "The discussion was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The discussion could not be updated.");
            return View(model);
        }

        // PUT: TelevisionDiscussion/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTelevisionDiscussion(Guid id, DiscussionEdit model)
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

            var service = NewDiscussionService();

            if (service.UpdateTelevisionDiscussion(model))
            {
                TempData["ResultSaved"] = "The discussion was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The discussion could not be updated.");
            return View(model);
        }

        // PUT: SportDiscussion/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSportDiscussion(Guid id, DiscussionEdit model)
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

            var service = NewDiscussionService();

            if (service.UpdateSportDiscussion(model))
            {
                TempData["ResultSaved"] = "The discussion was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The discussion could not be updated.");
            return View(model);
        }

        // DELETE: Discussion/Delete/{id}
        public ActionResult Delete(Guid id)
        {
            var service = NewDiscussionService();
            var model = service.GetDiscussionById(id);

            ViewBag.Discussion = service.GetDiscussionTitle(id);

            return View(model);
        }

        // POST: Discussion/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDiscussion(Guid id)
        {
            var service = NewDiscussionService();

            service.DeleteDiscussion(id);

            TempData["SaveResult"] = "The discussion was deleted.";

            return RedirectToAction("Index");
        }

        // ------------- Helper Method ------------------------
        private DiscussionService NewDiscussionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DiscussionService(userId);
            return service;
        }
    }
}