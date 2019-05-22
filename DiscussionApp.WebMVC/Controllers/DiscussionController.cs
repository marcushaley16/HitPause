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
        //SportService sportService = new SportService();

        // GET: Discussion
        [Route("")]
        public ActionResult Index()
        {
            var service = CreateDiscussionService();
            var model = service.GetDiscussions();

            ViewBag.UserId = Guid.Parse(User.Identity.GetUserId());

            //ViewBag.FilmId = 

            return View(model);
        }

        // GET: Discussion/Create
        public ActionResult Create()
        {
            //ViewBag.FilmId = new SelectList(filmService.GetFilms(), "FilmId", "Title");
            ViewBag.TelevisionId = new SelectList(tvService.GetTVShows(), "TelevisionId", "Title");
            //ViewBag.SportId = new SelectList(sportService.GetSports(), "SportId", "");

            return View();
        }

        // POST: Discussion/Create
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DiscussionCreate model)
        {
            model.DiscussionId = Guid.NewGuid();

            var service = CreateDiscussionService();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.FilmId != 0)
            {
                model.TelevisionId = 0;
                model.SportId = 0;
            }
            else if (model.TelevisionId != 0)
            {
                model.FilmId = 0;
                model.SportId = 0;
            }
            else if (model.SportId != 0)
            {
                model.FilmId = 0;
                model.TelevisionId = 0;
            }

            if (service.CreateDiscussion(model))
            {
                TempData["ResultSaved"] = "The discussion was created.";
                return RedirectToAction("Index", "Post", new { discussionId = model.DiscussionId });
            };

            ModelState.AddModelError("", "The discussion could not be created.");
            //ViewBag.FilmId = new SelectList(filmService.GetFilms(), "FilmId", "Title");

            return View(model);
        }

        //[HttpPost]
        //public JsonResult Film(MediaType mediaType)
        //{
        //    var filmList = .GetFilmsByType(mediaType);
        //    return Json(filmList, JsonRequestBehavior.AllowGet);
        //}

        // GET: Discussion/Detail/{id}
        public ActionResult Details(Guid id)
        {
            var service = CreateDiscussionService();
            var model = service.GetDiscussionById(id);

            ViewBag.Discussion = service.GetDiscussionTitle(id);

            return View(model);
        }

        // GET: Discussion/Edit/{id}
        public ActionResult Edit(Guid id)
        {
            var service = CreateDiscussionService();
            //DiscussionService service = new DiscussionService();
            //FilmService filmService = new FilmService();

            var detail = service.GetDiscussionById(id);
            //var filmDetail = filmService.GetFilmById(filmId);

            var model = new DiscussionEdit
            {
                DiscussionId = detail.DiscussionId,
                FilmId = detail.FilmId,
                MediaType = detail.MediaType,
                DiscussionTitle = detail.DiscussionTitle,
                //Film = detail.Film,
                //TVShow = detail.TVShow,
                //Sport = detail.Sport
            };

            ViewBag.Discussion = service.GetDiscussionTitle(id);
            ViewBag.FilmId = new SelectList(filmService.GetFilms(), "FilmId", "Title", detail.FilmId);
            return View(model);
        }

        // POST: Discussion/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, DiscussionEdit model)
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

            var service = CreateDiscussionService();

            if (service.UpdateDiscussion(model))
            {
                TempData["ResultSaved"] = "The discussion was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The discussion could not be updated.");
            return View(model);
        }

        // GET: Discussion/Delete/{id}
        public ActionResult Delete(Guid id)
        {
            var service = CreateDiscussionService();
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
            var service = CreateDiscussionService();

            service.DeleteDiscussion(id);

            TempData["SaveResult"] = "The discussion was deleted.";

            return RedirectToAction("Index");
        }

        // ------------- Helper Method ------------------------
        private DiscussionService CreateDiscussionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DiscussionService(userId);
            return service;
        }
    }
}