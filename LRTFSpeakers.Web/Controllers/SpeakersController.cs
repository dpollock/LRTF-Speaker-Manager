using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LRTFSpeakers.Web.Models;

namespace LRTFSpeakers.Web.Controllers
{
    [Authorize]
    public class SpeakersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Speakers
        public ActionResult Index()
        {
            var model = db.Speakers.Select(s => new SpeakerIndexVM
            {
                SpeakerId = s.Id,
                AttendingSpeakerDinner = s.AttendingSpeakerDinner,
                CityState = s.City + " " + s.State,
                FullName = s.FirstName + " " + s.LastName,
                HasConfirmedWebsiteDetails = s.HasConfirmedWebsiteDetails,
                HasHotelHandled = s.HasHotelHandled,
                HasInitialEmail = s.HasInitialEmail,
                Notes = s.Notes,
                PhotoUrl = s.Photo,
                ShirtSize = s.ShirtSize,
                TotalAccepted = s.Presentations.Count(p => p.Status == Status.Accepted || p.Status == Status.AwaitingAccepted),
                TotalPresentations = s.Presentations.Count,
                Twitter = s.Twitter,
                Website = s.Website,
                LRTFNotes = s.LRTFNotes,

            }).ToList();

            return View(model);
        }

        // GET: Speakers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speaker speaker = db.Speakers.Find(id);
            if (speaker == null)
            {
                return HttpNotFound();
            }
            return View(speaker);
        }

        // GET: Speakers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Speakers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Speaker speaker)
        {
            if (ModelState.IsValid)
            {
                db.Speakers.Add(speaker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(speaker);
        }

        // GET: Speakers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speaker speaker = db.Speakers.Find(id);
            if (speaker == null)
            {
                return HttpNotFound();
            }
            return View(speaker);
        }

        // POST: Speakers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Speaker speaker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(speaker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(speaker);
        }

        // GET: Speakers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speaker speaker = db.Speakers.Find(id);
            if (speaker == null)
            {
                return HttpNotFound();
            }
            return View(speaker);
        }

        // POST: Speakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Speaker speaker = db.Speakers.Find(id);
            db.Speakers.Remove(speaker);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
