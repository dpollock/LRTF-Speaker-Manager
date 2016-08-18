using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LRTFSpeakers.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LRTFSpeakers.Web.Controllers
{
    public class PresentationsController : Controller
    {
        private SpeakerContext db = new SpeakerContext();

        // GET: Presentations
        public ActionResult Index()
        {
            return View(db.Presentations.OrderBy(x => x.Status).ToList());
        }

        // GET: Presentations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Presentation presentation = db.Presentations.Find(id);
            if (presentation == null)
            {
                return HttpNotFound();
            }
            return View(presentation);
        }

        // GET: Presentations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Presentations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EntryID,Track,TopicTitle,TopicDescription,CreatedOn,Room,SessionNumber,Status,IsPrimaryPres")] Presentation presentation)
        {
            if (ModelState.IsValid)
            {
                db.Presentations.Add(presentation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(presentation);
        }

        // GET: Presentations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Presentation presentation = db.Presentations.Find(id);
            if (presentation == null)
            {
                return HttpNotFound();
            }
            return View(presentation);
        }

        // POST: Presentations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EntryID,Track,TopicTitle,TopicDescription,CreatedOn,Room,SessionNumber,Status,IsPrimaryPres")] Presentation presentation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(presentation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(presentation);
        }

        // GET: Presentations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Presentation presentation = db.Presentations.Find(id);
            if (presentation == null)
            {
                return HttpNotFound();
            }
            return View(presentation);
        }

        // POST: Presentations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Presentation presentation = db.Presentations.Find(id);
            db.Presentations.Remove(presentation);
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

        public ActionResult UpdateStatus(int id, int statusid)
        {
            var pres = db.Presentations.Find(id);
            pres.Status = (Status)statusid;
            db.SaveChanges();

            return Content($"{pres.Status}");
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(string jsonfile)
        {
            if (string.IsNullOrEmpty(jsonfile))
            {
                return View();
            }

            var convertedData = JsonConvert.DeserializeObject<List<PaperCallIOFormat>>(jsonfile);
            foreach (var pres in convertedData)
            {
                var existingSpeaker = db.Speakers.Include(x=>x.Presentations).FirstOrDefault(x => x.Email == pres.email);
                if (existingSpeaker == null)
                {
                    existingSpeaker = new Speaker
                    {
                        Email = pres.email,
                        AttendingSpeakerDinner = false,
                        Bio = pres.bio,
                        Company = pres.organization,
                        Twitter = pres.twitter,
                        Website = pres.url,
                        Notes = pres.notes,
                        Presentations = new List<Presentation>()
                    };

                    var name = pres.name.Split(' ');
                    if (name.Length == 2)
                    {
                        existingSpeaker.FirstName = name[0];
                        existingSpeaker.LastName = name[1];
                    }
                    else
                    {
                        existingSpeaker.FirstName = pres.name;
                    }

                    var location = pres.location.Split(',');
                    if (location.Length == 2)
                    {
                        existingSpeaker.City = location[0];
                        existingSpeaker.State = location[1];
                    }

                    db.Speakers.Add(existingSpeaker);
                }
                else
                {
                    if (existingSpeaker.FullName.ToLower() != pres.name.ToLower())
                    {
                        //different speaker...show error maybe?
                    }
                    else
                    {
                        //existingSpeaker.Bio = pres.bio;
                        //existingSpeaker.Company = pres.organization;
                        //existingSpeaker.Twitter = pres.twitter;
                        //existingSpeaker.Website = pres.url;
                        //existingSpeaker.Notes = pres.notes; //don't want to override current notes.
                    }
                }

                var existingPres = existingSpeaker.Presentations.FirstOrDefault(x => x.TopicTitle == pres.title);
                if (existingPres == null)
                {
                    existingPres = new Presentation();
                    existingSpeaker.Presentations.Add(existingPres);
                    existingPres.CreatedOn = DateTime.Now;
                    existingPres.TopicTitle = pres.title;
                    existingPres.TopicDescription = pres.description;
                    existingPres.IsPrimaryPres = existingSpeaker.Presentations.Count() == 1;
                    existingPres.MainSpeaker = existingSpeaker;
                    existingPres.Status = Status.Accepted;

                }

                

            }

            db.SaveChanges();

            TempData["message"] = "File Imported";
            return RedirectToAction("Index");
        }

    }
}
