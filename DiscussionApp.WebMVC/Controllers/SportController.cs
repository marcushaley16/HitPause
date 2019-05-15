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
    public class SportController : Controller
    {
        // GET: Sport
        public ActionResult Index()
        {
            var service = new SportService();
            var model = service.GetSports();

            return View(model);
        }

        // GET: Sport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sport/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SportCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new SportService();

            if (service.CreateSport(model))
            {
                TempData["SaveResult"] = "The sporting event was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The sporting event could not be created.");

            return View(model);
        }

        // GET: Sport/Detail/{id}
        public ActionResult Details(int id)
        {
            var service = new SportService();
            var model = service.GetSportById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = new SportService();

            var detail = service.GetSportById(id);
            var model = new SportEdit
            {
                SportId = detail.SportId,
                MediaType = detail.MediaType,
                League = detail.League,
                HomeTeam = detail.HomeTeam,
                AwayTeam = detail.AwayTeam,
                Location = detail.Location,
                Time = detail.Time,
                Network = detail.Network,
                Score = detail.Score
            };
            return View(model);
        }

        // POST: Sport/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SportEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.SportId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new SportService();

            if (service.UpdateSport(model))
            {
                TempData["SaveResult"] = "The sporting event was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The sporting event could not be updated.");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var service = new SportService();
            var model = service.GetSportById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSport(int id)
        {
            var service = new SportService();

            if (service.DeleteSport(id))
            {
                return RedirectToAction("Index");
            }

            TempData["SaveResult"] = "The sporting event was deleted.";

            return RedirectToAction("Delete", new { id });
        }
    }
}