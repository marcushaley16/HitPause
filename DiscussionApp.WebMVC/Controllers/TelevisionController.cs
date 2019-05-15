using DiscussionApp.Models;
using DiscussionApp.Services;
using DiscussionApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiscussionApp.WebMVC.Controllers
{
    [Authorize]
    public class TelevisionController : Controller
    {
        // GET: Show
        public ActionResult Index()
        {
            var service = new TelevisionService();
            var model = service.GetTVShows().OrderBy(x => x.Title);

            return View(model);
        }

        // GET: Show/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Show/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TVShowCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new TelevisionService();

            if (service.CreateTVShow(model))
            {
                TempData["SaveResult"] = "The show was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The show could not be created.");

            return View(model);

        }

        // GET: Show/Detail/{id}
        public ActionResult Details(int id)
        {
            var service = new TelevisionService();
            var model = service.GetTVShowById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = new TelevisionService();

            var detail = service.GetTVShowById(id);
            var model = new TVShowEdit
            {
                TelevisionId = detail.TelevisionId,
                MediaType = detail.MediaType,
                Title = detail.Title,
                Year = detail.Year,
                Creator = detail.Creator,
                Synopsis = detail.Synopsis,
                Stars = detail.Stars,
                Genre1 = detail.Genre1,
                Genre2 = detail.Genre2,
                Network = detail.Network,
                Released = detail.Released,
                Runtime = detail.Runtime,
                Rating = detail.Rating
                //Director = detail.Director,
                //Writer = detail.Writer,
                //Cinematographer = detail.Cinematographer,
                //Editor = detail.Editor,
                //DateAired = detail.DateAired
            };
            return View(model);
        }

        // POST: Film/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TVShowEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.TelevisionId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new TelevisionService();

            if (service.UpdateTVShow(model))
            {
                TempData["SaveResult"] = "The show was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The Show could not be updated.");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var service = new TelevisionService();
            var model = service.GetTVShowById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTVShow(int id)
        {
            var service = new TelevisionService();

            if (service.DeleteTVShow(id))
            {
                return RedirectToAction("Index");
            }

            TempData["SaveResult"] = "The show was deleted.";

            return RedirectToAction("Delete", new { id });
        }
    }
}